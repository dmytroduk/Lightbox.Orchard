using System;
using System.Collections.Generic;
using System.IO;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxSettings
    {
        public bool Enabled { get; set; }

        public string ContainerSelector { get; set; }

        public IList<string> LinkClasses { get; set; }

        public string LinkRelAttributeValue { get; set; }

        public bool ImageChildTagRequired { get; set; }

        public bool LinkToImageRequired { get; set; }

        public IList<string> ImageFileExtensions { get; set; }

        public string CustomScript { get; set; }

        public string CurrentTheme { get; set; }
    }
}