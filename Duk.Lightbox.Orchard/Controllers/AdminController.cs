using System.Linq;
using System.Web.Mvc;
using Duk.Lightbox.Orchard.Models;
using Duk.Lightbox.Orchard.Services;

namespace Duk.Lightbox.Orchard.Controllers
{
    public class AdminController : Controller
    {
        ILightboxService _lightboxService;

        public AdminController(ILightboxService lightboxService)
        {
            _lightboxService = lightboxService;
        }

        public ActionResult Index()
        {
            var model = new ThemeViewModel();
            model.AvailableThemes = _lightboxService.GetAvailableThemes().Select(t => t.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult SetCurrentTheme()
        {
            return RedirectToAction("Index");
        }
    }
}