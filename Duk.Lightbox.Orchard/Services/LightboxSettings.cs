
namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxSettings
    {
        public virtual bool Enabled { get; set; }

        public virtual string ContainerSelector { get; set; }

        public virtual bool ImageChildTagRequired { get; set; }

        public virtual bool LinkToImageRequired { get; set; }

        public virtual string ImageFileExtensions { get; set; }

        public virtual string CurrentTheme { get; set; }
    }
}