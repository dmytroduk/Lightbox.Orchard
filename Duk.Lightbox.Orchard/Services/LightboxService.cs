using System;
using System.Collections.Generic;
using System.Linq;
using Duk.Lightbox.Orchard.Records;
using Orchard.Data;
using System.IO;

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
            if (settings != null &&  !String.IsNullOrEmpty(settings.CurrentTheme))
            {
                currentTheme = availableTheme.FirstOrDefault(t => 
                    t.Name.Equals(settings.CurrentTheme, StringComparison.OrdinalIgnoreCase));                
            }

            return currentTheme ?? GetAvailableThemes().FirstOrDefault();
        }

        public void SetCurrentTheme(string theme)
        {
            var settings = GetSettingsToUpdate();

            settings.CurrentTheme = theme;
        }

        public LightboxSettings GetSettings()
        {
            var settingsRecord = _settingsRepository.Table.SingleOrDefault();
            if (settingsRecord == null)
            {
                return GetDefaultSettings();
            }
            var settings = new LightboxSettings 
            {
                Enabled = settingsRecord.Enabled,
                ContainerSelector = settingsRecord.ContainerSelector,
                ImageChildTagRequired = settingsRecord.ImageChildTagRequired,
                LinkToImageRequired = settingsRecord.LinkToImageRequired,   
                ImageFileExtensions = new List<string>(),
                CurrentTheme = settingsRecord.CurrentTheme                
            };
            if (!String.IsNullOrWhiteSpace(settingsRecord.ImageFileExtensions))
            {
                var stringReader = new StringReader(settingsRecord.ImageFileExtensions);
                string extension = null;
                while ((extension = stringReader.ReadLine()) != null)
                {
                    if (!String.IsNullOrWhiteSpace(extension))
                    {
                        settings.ImageFileExtensions.Add(extension);
                    }
                }
            }
            return settings;
        }

        public LightboxSettings GetDefaultSettings()
        {
            return new LightboxSettings
                       {
                           Enabled = true,
                           ContainerSelector = "#content",
                           ImageChildTagRequired = false,
                           LinkToImageRequired = true,
                           ImageFileExtensions = new List<string> { "jpg", "jpeg", "png", "gif", "bmp", "tif", "tiff" },
                           CurrentTheme = null
                       };
        }

        public void SaveSettings(LightboxSettings settings)
        {
            var settingsRecord = GetSettingsToUpdate();
            settingsRecord.Enabled = settings.Enabled;
            settingsRecord.ContainerSelector = settings.ContainerSelector;
            settingsRecord.ImageChildTagRequired = settings.ImageChildTagRequired;
            settingsRecord.LinkToImageRequired = settings.LinkToImageRequired;
            settingsRecord.ImageFileExtensions = String.Join(Environment.NewLine, settings.ImageFileExtensions ?? new string[] { });
            if (settings.CurrentTheme != null)
            {
                settingsRecord.CurrentTheme = settings.CurrentTheme;
            }
        }

        private SettingsRecord GetSettingsToUpdate()
        {
            var settings = _settingsRepository.Table.SingleOrDefault();
            if (settings == null)
            {
                settings = new SettingsRecord();
                _settingsRepository.Create(settings);
            }
            return settings;
        }
    }
}