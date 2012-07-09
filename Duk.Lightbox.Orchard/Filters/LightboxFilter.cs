using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Services;
using Duk.Lightbox.Orchard.Controllers;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;
using System;
using Duk.Lightbox.Orchard.Models;

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

            LightboxTheme currentTheme = null;
            if (filterContext.Controller is AdminController)
            {
                var previewTheme = viewResult.Model as ThemeViewModel;
                if (previewTheme != null && !String.IsNullOrWhiteSpace(previewTheme.CurrentThemeName))
                {
                    currentTheme = _lightboxService.GetAvailableThemes()
                        .FirstOrDefault(t => t.Name.Equals(previewTheme.CurrentThemeName, StringComparison.OrdinalIgnoreCase));
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
            _resourceManager.Require("script", ResourceManifest.ColorBoxScriptID).AtHead();
            _resourceManager.Require("script", ResourceManifest.LightboxLoaderScriptID).AtHead();            
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}