using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace Duk.Lightbox.Orchard
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public const string ColorBoxScriptID = "LightBox_ColorBox";
        public const string LightboxLoaderScriptID = "LightBox_Loader";

        public const string ColorBoxLightTheme = "LightBox_ColorBox_Light";
        public const string ColorBoxDarkTheme = "LightBox_ColorBox_Dark";

        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript(ColorBoxScriptID).SetUrl("colorbox/jquery.colorbox-min.js", "colorbox/jquery.colorbox.js").SetVersion("1.3.19");

            manifest.DefineStyle(ColorBoxLightTheme).SetUrl("themes/light/colorbox.css").SetVersion("1.8.18");
            manifest.DefineStyle(ColorBoxDarkTheme).SetUrl("themes/dark/colorbox.css").SetVersion("1.8.18");

            manifest.DefineScript(LightboxLoaderScriptID).SetUrl("loader.js").SetVersion("1.0.0");
        }
    }
}