using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Models;
using Duk.Lightbox.Orchard.Services;
using Orchard;
using Orchard.Security;
using Orchard.Themes;
using System;
using Orchard.Environment.Extensions;
using System.Web;
using Orchard.Environment.Extensions.Models;

namespace Duk.Lightbox.Orchard.Controllers
{
    public class AdminController : Controller
    {
        IOrchardServices _orchardServices;
        ILightboxService _lightboxService;
        string _modulePath;

        public AdminController(IOrchardServices orchardServices, IExtensionManager extensionManager, ILightboxService lightboxService)
        {
            _orchardServices = orchardServices;
            var moduleDescriptor = extensionManager.GetExtension("Duk.Lightbox.Orchard");
            _modulePath = VirtualPathUtility.AppendTrailingSlash(VirtualPathUtility.Combine(
                VirtualPathUtility.AppendTrailingSlash(VirtualPathUtility.ToAbsolute(moduleDescriptor.Location)), 
                moduleDescriptor.Path));
            _lightboxService = lightboxService;
        }

        public ActionResult Index(string currentThemeName)
        {            
            var availableThemes = _lightboxService.GetAvailableThemes();
            var currentTheme = _lightboxService.GetCurrentTheme();

            var model = new ThemeViewModel();
            model.CurrentThemeName = !String.IsNullOrWhiteSpace(currentThemeName) && 
                availableThemes.Any(t => t.Name.Equals(currentThemeName, StringComparison.OrdinalIgnoreCase)) ? 
                    currentThemeName : currentTheme.Name;
            model.IsPreview = !model.CurrentThemeName.Equals(currentTheme.Name, StringComparison.OrdinalIgnoreCase);
            model.AvailableThemes = availableThemes.Select(t => t.Name).ToList();
            model.TestImagePath = VirtualPathUtility.Combine(_modulePath, "Content/TestImage.jpg");
            model.TestImageThumbnailPath = VirtualPathUtility.Combine(_modulePath, "Content/TestImage_thumb.jpg");

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(string currentThemeName, bool isPreview)
        {
            if (!_orchardServices.Authorizer.Authorize(StandardPermissions.SiteOwner))
            {
                return new HttpUnauthorizedResult();
            }

            if (isPreview || !ModelState.IsValid)
            {
                return Index(currentThemeName);
            }

            _lightboxService.SetCurrentTheme(currentThemeName);

            return Index(null);
        }
    }
}