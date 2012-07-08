using System.Collections.Generic;
using System.Linq;
using Orchard;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxService : ILightboxService, IDependency
    {
        public IEnumerable<LightboxTheme> GetAvailableThemes()
        {
            return new[] 
            { 
                new LightboxTheme {Name = "light", CssResources = new Dictionary<string, string> {
                    {"lightStyles", "themes/light/colorbox.css"}
                }},
                    new LightboxTheme {Name = "dark", CssResources = new Dictionary<string, string> {
                    {"darkStyles", "themes/dark/colorbox.css"}
                }}
            };
        }

        public LightboxTheme GetCurrentTheme()
        {
            return GetAvailableThemes().FirstOrDefault(t => t.Name.Equals("light", System.StringComparison.OrdinalIgnoreCase));
        }

        public void SetCurrentTheme(string theme)
        {
            ;
        }
    }
}