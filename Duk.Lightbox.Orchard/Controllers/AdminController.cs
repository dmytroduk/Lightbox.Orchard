using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Models;
using Duk.Lightbox.Orchard.Services;
using Orchard;
using Orchard.Security;
using Orchard.Themes;

namespace Duk.Lightbox.Orchard.Controllers
{
    public class AdminController : Controller
    {
        IOrchardServices _orchardServices;
        ILightboxService _lightboxService;

        public AdminController(IOrchardServices orchardServices, ILightboxService lightboxService)
        {
            _orchardServices = orchardServices;
            _lightboxService = lightboxService;
        }

        public ActionResult Index()
        {
            var model = new ThemeViewModel();
            model.CurrentThemeName = _lightboxService.GetCurrentTheme().Name;
            model.AvailableThemes = _lightboxService.GetAvailableThemes().Select(t => t.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult SetCurrentTheme(string currentThemeName)
        {
            if (!_orchardServices.Authorizer.Authorize(StandardPermissions.SiteOwner))
            {
                return new HttpUnauthorizedResult();
            }

            if (!ModelState.IsValid)
            {
                return Index();
            }

            _lightboxService.SetCurrentTheme(currentThemeName);

            return RedirectToAction("Index");
        }
    }
}