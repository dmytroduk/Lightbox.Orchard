$(function () {

    if (!lightboxSettings) {
        return;
    }

    $(lightboxSettings.containerQuery).find("a").each(function (index, link) {
        var linkUrl = $(link).attr("href");
        if (!linkUrl || linkUrl.length < 1 || linkUrl[0] === "#") {
            return;
        }
        if (lightboxSettings.linkClasses && lightboxSettings.linkClasses.length > 0) {
            if (!link.is("." + lightboxSettings.linkClasses.join(", ."))) {
                return;
            }
        }
        var processLink = true;
        var uri = new URI(linkUrl);
        if (lightboxSettings.imageChildTagRequired) {
            processLink &= $(link).children("img").length == 1;
        }
        if (processLink && lightboxSettings.linkToImageRequired) {
            var suffix = uri.suffix();
            processLink &= suffix && suffix.length > 0 &&
                $.inArray(suffix, lightboxSettings.imageFileExtensions) >= 0;
        }
        if (processLink) {
            $(link).colorbox();
        }
    });
    
});