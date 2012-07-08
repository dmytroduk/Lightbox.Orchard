using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Duk.Lightbox.Orchard.Services;
using Orchard.UI.Resources;

namespace Duk.Lightbox.Orchard
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public const string ColorBoxScriptID = "LightBox_ColorBox";
        public const string LightboxLoaderScriptID = "LightBox_Loader";

        readonly ILightboxService _lightboxService;

        public ResourceManifest(ILightboxService lightboxService)
        {
            _lightboxService = lightboxService;
        }

        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript(ColorBoxScriptID).SetUrl("colorbox/jquery.colorbox-min.js", "colorbox/jquery.colorbox.js").SetVersion("1.3.19");

            var themeResources = _lightboxService.GetAvailableThemes().SelectMany(t => t.CssResources).ToList();
            themeResources.ForEach(resource => manifest.DefineStyle(resource.Key).SetUrl(resource.Value));

            manifest.DefineScript(LightboxLoaderScriptID).SetUrl("loader.js").SetVersion("1.0.0");
        }
    }
}