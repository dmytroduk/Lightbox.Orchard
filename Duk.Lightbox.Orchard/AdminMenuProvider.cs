using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace Duk.Lightbox.Orchard
{
    public class AdminMenuProvider : INavigationProvider
    {
        public Localizer T { get; set; }

        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Settings"), menu => menu
                    .Add(T("Lightbox"), "5.0", 
                        lightboxMenu => lightboxMenu
                            .Action("Index", "Admin", new { area = "Duk.Lightbox.Orchard" })
                                    .Permission(StandardPermissions.SiteOwner)
                                .Add(T("Settings"), "1.0", 
                                    item => item.Action("Index", "Admin", new { area = "Duk.Lightbox.Orchard" })
                                        .Permission(StandardPermissions.SiteOwner).LocalNav())
                                .Add(T("Theme"), "2.0", 
                                    item => item.Action("Theme", "Admin", new { area = "Duk.Lightbox.Orchard" })
                                        .Permission(StandardPermissions.SiteOwner).LocalNav())
                    ));
        }
    }
}