using System.Collections.Generic;
using Duk.Lightbox.Orchard.Records;
using Orchard;

namespace Duk.Lightbox.Orchard.Services
{
    public interface ILightboxService : IDependency
    {
        IEnumerable<LightboxTheme> GetAvailableThemes();

        LightboxTheme GetCurrentTheme();

        void SetCurrentTheme(string theme);

        LightboxSettings GetSettings();

        LightboxSettings GetDefaultSettings();

        void SaveSettings(LightboxSettings settings);
    }
}
