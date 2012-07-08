using System.Collections.Generic;

namespace Duk.Lightbox.Orchard.Models
{
    public class ThemeViewModel
    {
        public string CurrentTheme
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