using System.Linq;
using Duk.Lightbox.Orchard.Services;
using Orchard.UI.Resources;

namespace Duk.Lightbox.Orchard
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public const string ColorBoxScriptId = "LightBox_ColorBox";
        public const string UriJsId = "uri.js";
        public const string LightboxLoaderScriptId = "LightBox_Loader";

        readonly ILightboxService _lightboxService;

        public ResourceManifest(ILightboxService lightboxService)
        {
            _lightboxService = lightboxService;
        }

        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript(ColorBoxScriptId).SetUrl("colorbox/jquery.colorbox-min.js", "colorbox/jquery.colorbox.js").SetVersion("1.3.19");

            var themeResources = _lightboxService.GetAvailableThemes().SelectMany(t => t.CssResources).ToList();
            themeResources.ForEach(resource => manifest.DefineStyle(resource.Key).SetUrl(resource.Value));

            manifest.DefineScript(UriJsId).SetUrl("uri/URI.min.js");

            manifest.DefineScript(LightboxLoaderScriptId).SetUrl("loader.js").SetVersion("1.0.0");
        }
    }
}