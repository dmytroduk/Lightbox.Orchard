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

        public bool IsPreview
        {
            get;
            set;
        }

        public IList<string> AvailableThemes
        {
            get;
            set;
        }

        public string TestImagePath
        {
            get;
            set;
        }

        public string TestImageThumbnailPath
        {
            get;
            set;
        }
    }
}