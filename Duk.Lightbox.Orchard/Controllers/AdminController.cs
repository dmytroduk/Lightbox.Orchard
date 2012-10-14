using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Models;
using Duk.Lightbox.Orchard.Services;
using Orchard;
using Orchard.Security;
using System;
using Orchard.Environment.Extensions;
using System.Web;

namespace Duk.Lightbox.Orchard.Controllers
{
    public class AdminController : Controller
    {
        readonly IOrchardServices _orchardServices;
        readonly ILightboxService _lightboxService;
        readonly string _modulePath;

        public AdminController(IOrchardServices orchardServices, IExtensionManager extensionManager, ILightboxService lightboxService)
        {
            _orchardServices = orchardServices;
            var moduleDescriptor = extensionManager.GetExtension("Duk.Lightbox.Orchard");
            _modulePath = VirtualPathUtility.AppendTrailingSlash(VirtualPathUtility.Combine(
                VirtualPathUtility.AppendTrailingSlash(VirtualPathUtility.ToAbsolute(moduleDescriptor.Location)), 
                moduleDescriptor.Path));
            _lightboxService = lightboxService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(bool enable)
        {
            return View();
        }

        public ActionResult Theme(string selectedTheme)
        {            
            var availableThemes = _lightboxService.GetAvailableThemes().ToList();
            var currentTheme = _lightboxService.GetCurrentTheme();

            var model = new ThemeViewModel
            {
                CurrentTheme = !String.IsNullOrWhiteSpace(selectedTheme) &&
                                   availableThemes.Any(
                                       t =>
                                       t.Name.Equals(selectedTheme,
                                                     StringComparison.OrdinalIgnoreCase))
                                    ? selectedTheme
                                    : currentTheme.Name
            };
            model.IsPreview = !model.CurrentTheme.Equals(currentTheme.Name, StringComparison.OrdinalIgnoreCase);
            model.AvailableThemes = availableThemes.Select(t => t.Name).ToList();
            model.TestImagePath = VirtualPathUtility.Combine(_modulePath, "Content/TestImage.jpg");
            model.TestImageThumbnailPath = VirtualPathUtility.Combine(_modulePath, "Content/TestImage_thumb.jpg");

            return View("Theme", model);
        }

        [HttpPost]
        public ActionResult Theme(string currentTheme, bool isPreview)
        {
            if (!_orchardServices.Authorizer.Authorize(StandardPermissions.SiteOwner))
            {
                return new HttpUnauthorizedResult();
            }

            if (isPreview || !ModelState.IsValid)
            {
                return Theme(currentTheme);
            }

            _lightboxService.SetCurrentTheme(currentTheme);

            return Theme(null);
        }
    }
}