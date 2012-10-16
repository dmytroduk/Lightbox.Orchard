using System;
using System.Collections.Generic;
using System.IO;

namespace Duk.Lightbox.Orchard.Services
{
    public class LightboxSettings
    {
        public bool Enabled { get; set; }

        public string ContainerSelector { get; set; }

        public bool ImageChildTagRequired { get; set; }

        public bool LinkToImageRequired { get; set; }

        public IList<string> ImageFileExtensions { get; set; }

        public string CurrentTheme { get; set; }

        public static string GetExtensionsAsString(IList<string> extensions)
        {
            return String.Join(Environment.NewLine, extensions ?? new string[] { });
        }

        public static IList<string> GetExtensionsAsList(string extensions)
        {
            var list = new List<string>();
            if (!String.IsNullOrWhiteSpace(extensions))
            {
                var stringReader = new StringReader(extensions);
                string extension = null;
                while ((extension = stringReader.ReadLine()) != null)
                {
                    if (!String.IsNullOrWhiteSpace(extension))
                    {
                        list.Add(extension);
                    }
                }
            }
            return list;
        }
    }
}