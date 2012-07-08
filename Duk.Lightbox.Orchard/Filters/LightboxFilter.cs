using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Mvc.Filters;
using System.Web.Mvc;
using Orchard.UI.Resources;
using Orchard.Environment.Extensions;

namespace Duk.Lightbox.Orchard.Filters
{
    public class LightboxFilter : FilterProvider, IResultFilter
    {
        private readonly IResourceManager _resourceManager;

        public LightboxFilter(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null)
            {
                return;
            }

            _resourceManager.Require("stylesheet", ResourceManifest.ColorBoxLightTheme).AtHead();

            _resourceManager.Require("script", "jQuery").AtHead();
            _resourceManager.Require("script", ResourceManifest.ColorBoxScriptID).AtHead();
            _resourceManager.Require("script", ResourceManifest.LightboxLoaderScriptID).AtHead();            
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}