﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StefanStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                   "",
                    new
                    {
                        controller = "Product",
                        action = "ListProducts",
                        category = (string)null,
                        page = 1
                    }
                    );

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Product", action = "ListProducts", category = (string)null },
                new { page = @"\d+" }
                );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Product", action = "ListProducts", page = 1 }
                );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Product", action = "ListProducts" },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}