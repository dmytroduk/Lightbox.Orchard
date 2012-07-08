using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Navigation;
using Orchard.Localization;
using Orchard.Core.Navigation;
using Orchard.Security;

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
                            .Add(T("Lightbox"), "5.0", 
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