using System.Collections.Generic;

namespace Duk.Lightbox.Orchard.Models
{
    public class ThemeViewModel
    {
        public string CurrentThemeName
        {
            get;
            set;
        }

        public IList<string> AvailableThemes
        {
            get;
            set;
        }
    }
}