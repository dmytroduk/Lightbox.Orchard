using System.Collections.Generic;
using System.Linq;
using Duk.Lightbox.Orchard.Records;
using Orchard;
using Orchard.Data;
using System;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxService : ILightboxService, IDependency
    {
        IRepository<SettingsRecord> _settingsRepository;

        public LightboxService(IRepository<SettingsRecord> settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public IEnumerable<LightboxTheme> GetAvailableThemes()
        {
            return new[] 
            { 
                new LightboxTheme {Name = "Light", CssResources = new Dictionary<string, string> {
                    {"lightStyles", "themes/light/colorbox.css"}
                }},
                    new LightboxTheme {Name = "Dark", CssResources = new Dictionary<string, string> {
                    {"darkStyles", "themes/dark/colorbox.css"}
                }}
            };
        }

        public LightboxTheme GetCurrentTheme()
        {
            var settings = _settingsRepository.Table.SingleOrDefault();
            var availableTheme = GetAvailableThemes();
            LightboxTheme currentTheme = null;
            if (settings != null || !String.IsNullOrEmpty(settings.CurrentThemeName))
            {
                currentTheme = availableTheme.FirstOrDefault(t => 
                    t.Name.Equals(settings.CurrentThemeName, System.StringComparison.OrdinalIgnoreCase));                
            }

            if (currentTheme == null)
            {
                currentTheme = GetAvailableThemes().FirstOrDefault(); 
            }

            return currentTheme;
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