
using System.ComponentModel.DataAnnotations;
namespace Duk.Lightbox.Orchard.Models
{
    public class SettingsViewModel
    {
        [Required]
        public bool Enabled { get; set; }

        [Required]
        public string ContainerSelector { get; set; }

        public string LinkClasses { get; set; }

        public string LinkRelAttributeValue { get; set; }

        [Required]
        public bool ImageChildTagRequired { get; set; }

        [Required]
        public bool LinkToImageRequired { get; set; }

        public string ImageFileExtensions { get; set; }

        public string CustomScript { get; set; }
    }
}