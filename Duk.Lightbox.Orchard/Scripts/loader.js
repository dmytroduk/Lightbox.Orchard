$(function () {

    var imageExtensions = ["jpg", "jpeg", "png", "gif", "bmp", "tif", "tiff"];

    var containerQuery = "#content";

    var processLinksWithImageInsideOnly = false;
    var processLinksToImageOnly = true;

    $(containerQuery).find("a").each(function(index, link) {
        var processLink = true;
        var uri = new URI($(link).attr("href"));
        if (processLinksWithImageInsideOnly) {
            processLink &= $(link).children("img").length == 1;
        }
        if (processLink && processLinksToImageOnly) {
            var isLinkToImage = false;
            var i = 0;
            while (!isLinkToImage && i < imageExtensions.length) {
                isLinkToImage |= $.inArray(uri.suffix(), imageExtensions) >= 0;
                i++;
            }
            processLink &= isLinkToImage;
        }
        if (processLink) {
            $(link).colorbox();
        }
    });
    
});