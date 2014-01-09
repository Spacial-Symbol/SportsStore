using System.Web.Mvc;
using System.Web.Routing;

namespace ProdcutSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //this is done by gaurav Uniyal
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,"",
                            // Only matches the empty URL (i.e. /) 
                            new
                                {
                                    controller = "Product",
                                    action = "List",
                                    category = (string) null,
                                    page = 1
                                });

            routes.MapRoute(null, "Page{page}",
                        //Matches /Page1 , /Page123 ,but not pagexyz
                        new { Controller = "Product", action = "List", category  = (string )null },
                        new { page = @"\d+"} //// Constraints: page must be numerical                             
                );

            routes.MapRoute(null, "{category}",
                            // Matches /Football or /AnythingWithNoSlash         
                            new {controller = "Product", action = "List", page = 1}
                );

            routes.MapRoute(null, "{category}/Page{page}",
                            // Matches /Football/Page567         
                            new {controller = "Product", action = "List"},
                            // Defaults        
                            new {page = @"\d+"}
                // Constraints: page must be numerical 
                );    
            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}