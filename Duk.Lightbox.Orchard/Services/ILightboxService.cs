using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duk.Lightbox.Orchard.Services
{
    public interface ILightboxService
    {
        string GetCurrentTheme();

        void SetCurrentTheme(string theme);
    }
}
