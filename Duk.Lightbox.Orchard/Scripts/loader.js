/// <reference path="..\..\..\Orchard.jQuery\Scripts\jquery-1.7.1-vsdoc.js" />

$(function () {
    $("#content").find("img").each(function () {
        //read the parent
        var parentLinkObject = $(this).parent().first();
        if (parentLinkObject.is("a")) {
            //read the attribute 'href'
            hrefAttribute = $(parentLinkObject).attr("href");
            //look for graphical file types            
            $(parentLinkObject).colorbox();
        }
    });
});