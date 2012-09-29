/// <reference path="..\..\..\Orchard.jQuery\Scripts\jquery-1.7.1-vsdoc.js" />

$(function () {
    $("#content").find("img").each(function () {
        var parentLink = $(this).parent().first();
        if (parentLink.is("a")) {
            var href = $(parentLink).attr("href");
            // check that this is link to image
            $(parentLink).colorbox();
        }
    });
});