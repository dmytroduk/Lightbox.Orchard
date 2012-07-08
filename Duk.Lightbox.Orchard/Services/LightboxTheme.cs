using System.Collections.Generic;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxTheme
    {
        public string Name
        {
            get;
            set;
        }

        public IDictionary<string, string> CssResources
        {
            get;
            set;
        }
    }
}
