using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Services;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

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

            var currentTheme = _lightboxService.GetCurrentTheme();
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