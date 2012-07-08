using System.Collections.Generic;
using Orchard;

namespace Duk.Lightbox.Orchard.Services
{
    public interface ILightboxService : IDependency
    {
        IEnumerable<LightboxTheme> GetAvailableThemes();

        LightboxTheme GetCurrentTheme();

        void SetCurrentTheme(string theme);
    }
}
