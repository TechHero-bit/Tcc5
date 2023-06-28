using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TCC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "SalvarItemT",
               url: "Adm/SalvarItemT",
               defaults: new { controller = "Adm", action = "SalvarItemT" });

            routes.MapRoute(
               name: "SalvarItem",
               url: "Adm/SalvarItem",
               defaults: new { controller = "Adm", action = "SalvarItem" });

            routes.MapRoute(
               name: "SalvarCard",
               url: "Adm/SalvarCard",
               defaults: new { controller = "Adm", action = "SalvarCard" });

            routes.MapRoute(
              name: "SalvarSetor",
              url: "Adm/SalvarSetor",
              defaults: new { controller = "Adm", action = "SalvarSetor" });

            routes.MapRoute(
              name: "SalvarLogin",
              url: "Adm/SalvarLogin",
              defaults: new { controller = "Adm", action = "SalvarLogin" });

            routes.MapRoute(
              name: "SalvarTipofunc",
              url: "Adm/SalvarTipoFunc",
              defaults: new { controller = "Adm", action = "SalvarTipofunc" });

            routes.MapRoute(
              name: "SalvarSecao",
              url: "Adm/SalvarSecao",
              defaults: new { controller = "Adm", action = "SalvarSecao" });

            routes.MapRoute(
              name: "SalvarMesaSecao",
              url: "Adm/SalvarMesaSecao",
              defaults: new { controller = "Adm", action = "SalvarMesaSecao" });

            routes.MapRoute(
             name: "SalvarMesa",
             url: "Adm/SalvarMesa",
             defaults: new { controller = "Adm", action = "SalvarMesa" });

            routes.MapRoute(
             name: "SalvarCouvert",
             url: "Garcom/SalvarCouvert",
             defaults: new { controller = "Garcom", action = "SalvarCouvert" });

            routes.MapRoute(
             name: "SalvarComanda",
             url: "Garcom/SalvarComanda",
             defaults: new { controller = "Garcom", action = "SalvarComanda" });





            routes.MapRoute(
             name: "ItemAlterar",
             url: "Adm/:id/ItemAlterar",
             defaults: new { controller = "Adm", action = "ItemAlterar", id = 0 });


            routes.MapRoute(
             name: "ExcluirItem",
             url: "Adm/ExcluirItem/:id",
             defaults: new { controller = "Adm", action = "ExcluirItem", id = 0 });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
