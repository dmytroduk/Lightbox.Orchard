using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Duk.Lightbox.Orchard
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] 
            {
                new RouteDescriptor
                {
                    Route = new Route("Admin/Settings/Duk.Lightbox",
                        new RouteValueDictionary
                        {
                            { "area", "Duk.Lightbox.Orchard"},
                            { "controller", "Admin" },
                            { "action", "Index" }
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary
                        {
                            { "area", "Duk.Lightbox.Orchard" }
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}