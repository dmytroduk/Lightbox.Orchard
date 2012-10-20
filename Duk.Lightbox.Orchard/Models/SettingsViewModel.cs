
using System.ComponentModel.DataAnnotations;
namespace Duk.Lightbox.Orchard.Models
{
    public class SettingsViewModel
    {
        public bool Enabled { get; set; }

        [Required(ErrorMessage="Please input containder selector.")]
        [StringLength(1024, ErrorMessage = "Maximum length of container selector string is 1024.")]
        public string ContainerSelector { get; set; }

        [StringLength(1024, ErrorMessage = "Maximum length of CSS classes list is 1024.")]
        public string LinkClasses { get; set; }

        [StringLength(1024, ErrorMessage = "Maximum length of rel attribute value is 1024.")]
        public string LinkRelAttributeValue { get; set; }

        public bool ImageChildTagRequired { get; set; }

        public bool LinkToImageRequired { get; set; }

        [StringLength(1024, ErrorMessage = "Maximum length of image file extension list is 1024.")]
        public string ImageFileExtensions { get; set; }

        public string CustomScript { get; set; }
    }
}