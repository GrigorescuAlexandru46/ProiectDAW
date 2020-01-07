using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProiectDAW
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CheckChat",
                url: "chat/check/{ownProfileId}/{targetProfileId}",
                defaults: new { controller = "Chat", action = "Check" }
            );

            routes.MapRoute(
                name: "NewPhoto",
                url: "photo/new/{profileId}",
                defaults: new { controller = "Photo", action = "New" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
