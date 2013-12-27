using System.Linq;
using Duk.Lightbox.Orchard.Services;
using Orchard.UI.Resources;

namespace Duk.Lightbox.Orchard
{
    public class ResourceManifest : IResourceManifestProvider
    {
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

            var themeResources = _lightboxService.GetAvailableThemes().SelectMany(t => t.CssResources).ToList();
            themeResources.ForEach(resource => manifest.DefineStyle(resource.Key).SetUrl(resource.Value));

            manifest.DefineScript(UriJsId).SetUrl("uri/URI.min.js");

            manifest.DefineScript(LightboxLoaderScriptId).SetUrl("loader.js").SetVersion("1.1.0");
        }
    }
}