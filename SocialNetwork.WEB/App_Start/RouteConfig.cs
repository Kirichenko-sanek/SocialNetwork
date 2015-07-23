using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SocialNetwork.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


           
            routes.MapRoute(
                name: "Registration",
                url: "Account/Registration",
                defaults: new { controller = "Account", action = "Registration" }
            );
            routes.MapRoute(
                name: "AfterRegistration",
                url: "Account/EndRegistration",
                defaults: new { controller = "Account", action = "EndRegistration" }
            );

            routes.MapRoute(
                name: "AfterPassRecovery",
                url: "Account/EndPassRecovery",
                defaults: new { controller = "Account", action = "EndPassRecovery" }
            );

            routes.MapRoute(
                name: "ConfirmEmail",
                url: "Account/ConfirmEmail",
                defaults: new { controller = "Account", action = "ConfirmEmail" }
            );
            
            routes.MapRoute(
                name: "LogIn",
                url: "Account/LogIn",
                defaults: new { controller = "Account", action = "LogIn" }
            );
            
            routes.MapRoute(
              name: "Language",
              url: "Home/ChangeCulture",
              defaults: new { controller = "Home", action = "ChangeCulture" }
           );

            routes.MapRoute(
                name: "MyPage",
                url: "Profile/MyPage/{id}",
                defaults: new { controller = "Profile", action = "MyPage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
