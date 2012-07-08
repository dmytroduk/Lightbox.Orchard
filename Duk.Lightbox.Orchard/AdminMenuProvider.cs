using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace Duk.Lightbox.Orchard
{
    public class AdminMenuProvider : INavigationProvider
    {
        public Localizer T { get; set; }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Settings"), menu => menu
                    .Add(T("Lightbox"), "5.0", 
                        subMenu => subMenu.Action("Index", "Admin", new { area = "Duk.Lightbox.Orchard" })
                                .Permission(StandardPermissions.SiteOwner)
                            .Add(T("Lightbox theme"), "5.0", 
                                item => item.Action("Index", "Admin", new { area = "Duk.Lightbox.Orchard" })
                                    .Permission(StandardPermissions.SiteOwner).LocalNav())
                    ));
        }

        public string MenuName
        {
            get { return "admin"; }
        }
    }
}