
using System.ComponentModel.DataAnnotations;
namespace Duk.Lightbox.Orchard.Models
{
    public class SettingsViewModel
    {
        [Required]
        public virtual bool Enabled { get; set; }

        [Required]
        public virtual string ContainerSelector { get; set; }

        [Required]
        public virtual bool ImageChildTagRequired { get; set; }

        [Required]
        public virtual bool LinkToImageRequired { get; set; }

        public virtual string ImageFileExtensions { get; set; }
    }
}