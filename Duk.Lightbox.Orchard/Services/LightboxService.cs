using System;
using System.Collections.Generic;
using System.Linq;
using Duk.Lightbox.Orchard.Records;
using Orchard.Data;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxService : ILightboxService
    {
        readonly IRepository<SettingsRecord> _settingsRepository;

        public LightboxService(IRepository<SettingsRecord> settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public IEnumerable<LightboxTheme> GetAvailableThemes()
        {
            return new[] 
            { 
                new LightboxTheme {Name = "Light with controls in the top", CssResources = new Dictionary<string, string> {
                    {"lightTopStyles", "themes/LightTop/colorbox.css"}
                }},
                new LightboxTheme {Name = "Light with controls in the bottom", CssResources = new Dictionary<string, string> {
                    {"lightBottomStyles", "themes/LightBottom/colorbox.css"}
                }},
                new LightboxTheme {Name = "Dark with inline controls", CssResources = new Dictionary<string, string> {
                    {"darkInlineStyles", "themes/DarkInline/colorbox.css"}
                }},
                    new LightboxTheme {Name = "Dark with controls in the bottom", CssResources = new Dictionary<string, string> {
                    {"darkBottomStyles", "themes/DarkBottom/colorbox.css"}
                }}
            };
        }

        public LightboxTheme GetCurrentTheme()
        {
            var settings = _settingsRepository.Table.SingleOrDefault();
            var availableTheme = GetAvailableThemes();
            LightboxTheme currentTheme = null;
            if (settings != null &&  !String.IsNullOrEmpty(settings.CurrentThemeName))
            {
                currentTheme = availableTheme.FirstOrDefault(t => 
                    t.Name.Equals(settings.CurrentThemeName, StringComparison.OrdinalIgnoreCase));                
            }

            return currentTheme ?? GetAvailableThemes().FirstOrDefault();
        }

        public void SetCurrentTheme(string theme)
        {
            var settings = _settingsRepository.Table.SingleOrDefault();
            if (settings == null)
            {
                settings = new SettingsRecord();
                _settingsRepository.Create(settings);
            }

            settings.CurrentThemeName = theme;
        }
    }
}