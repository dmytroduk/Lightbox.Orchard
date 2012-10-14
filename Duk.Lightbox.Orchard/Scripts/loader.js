$(function () {

    var imageExtensions = ["jpg", "jpeg", "png", "gif", "bmp", "tif", "tiff"];

    var containerQuery = "#content";

    var processLinksWithImageInsideOnly = false;
    var processLinksToImageOnly = true;

    $(containerQuery).find("a").each(function(index, link) {
        var linkUrl = $(link).attr("href");
        if (!linkUrl || linkUrl.length < 1 || linkUrl[0] === "#") {
            return;
        }
        var processLink = true;
        var uri = new URI(linkUrl);
        if (processLinksWithImageInsideOnly) {
            processLink &= $(link).children("img").length == 1;
        }
        if (processLink && processLinksToImageOnly) {
            var suffix = uri.suffix();
            processLink &= suffix && suffix.length > 0 && $.inArray(suffix, imageExtensions) >= 0;
        }
        if (processLink) {
            $(link).colorbox();
        }
    });
    
});