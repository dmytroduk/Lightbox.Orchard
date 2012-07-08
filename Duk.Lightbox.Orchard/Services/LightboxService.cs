using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxService : ILightboxService, IDependency
    {
        public string GetCurrentTheme()
        {
            return "light";
        }

        public void SetCurrentTheme(string theme)
        {
            ;
        }
    }
}