using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Services;
using Duk.Lightbox.Orchard.Controllers;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;
using System;
using Duk.Lightbox.Orchard.Models;
using System.Globalization;

namespace Duk.Lightbox.Orchard.Filters
{
    public class LightboxFilter : FilterProvider, IResultFilter
    {
        readonly IResourceManager _resourceManager;
        readonly ILightboxService _lightboxService;

        public LightboxFilter(IResourceManager resourceManager, ILightboxService lightboxService)
        {
            _resourceManager = resourceManager;
            _lightboxService = lightboxService;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
            {
                return;
            }

            var settings = _lightboxService.GetSettings();
            var configuringLightbox = filterContext.Controller is AdminController;

            if (!settings.Enabled && !configuringLightbox)
            {
                return;
            }

            LightboxTheme currentTheme = null;
            if (configuringLightbox)
            {
                var previewTheme = viewResult.Model as ThemeViewModel;
                if (previewTheme != null && !String.IsNullOrWhiteSpace(previewTheme.CurrentTheme))
                {
                    currentTheme = _lightboxService.GetAvailableThemes()
                        .FirstOrDefault(t => t.Name.Equals(previewTheme.CurrentTheme, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (currentTheme == null)
            {
                currentTheme = _lightboxService.GetCurrentTheme();            
            }

            if (currentTheme != null)
            {
                currentTheme.CssResources.Keys.ToList().ForEach(name => _resourceManager.Require("stylesheet", name).AtHead());
            }            

            _resourceManager.Require("script", "jQuery").AtHead();
            _resourceManager.Require("script", ResourceManifest.ColorBoxScriptId).AtFoot();
            _resourceManager.Require("script", ResourceManifest.UriJsId).AtFoot();

            _resourceManager.RegisterHeadScript(String.Format(CultureInfo.InvariantCulture,
                "<script>lightboxSettings = {{ containerQuery: \"{0}\", linkClasses: [{1}], linkRelAttributeValue: {2}, imageChildTagRequired: {3}, linkToImageRequired: {4}, imageFileExtensions: [{5}]  }};</script>;",
                settings.ContainerSelector, 
                (settings.LinkClasses.Any() ? "\"" + String.Join("\", \"" , settings.LinkClasses) + "\"" : String.Empty),
                !String.IsNullOrWhiteSpace(settings.LinkRelAttributeValue) ? "\"" + settings.LinkRelAttributeValue + "\"" : "null",
                settings.ImageChildTagRequired.ToString().ToLower(), 
                settings.LinkToImageRequired.ToString().ToLower(),
                (settings.LinkToImageRequired ? "\"" + String.Join("\", \"", settings.ImageFileExtensions) + "\"" : String.Empty)));
            
            _resourceManager.Require("script", ResourceManifest.LightboxLoaderScriptId).AtFoot();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}