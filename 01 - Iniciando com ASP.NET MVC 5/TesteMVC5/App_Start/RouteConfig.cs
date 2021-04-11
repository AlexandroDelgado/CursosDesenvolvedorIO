using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TesteMVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // lê as rotas criadas nos controlers e não gera conflito entre elas (melhor que usar o MapRoute)
            routes.MapMvcAttributeRoutes();

            // Sempre colocar as rotas mais complexas por cima e testar muito bem para que não haja erro de navegação, já que o processamento das rotas seguem uma regra de cima para baixo.

            routes.MapRoute(
                name: "Institucional",
                url: "Institucional/{controller}/{action}",
                defaults: new { controller = "Teste", action = "IndexTeste" });

            routes.MapRoute(
                name: "Teste",
                url: "Sistema/{controller}/{action}/{id}",
                defaults: new { controller = "Teste", action = "IndexTeste", id = UrlParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

                //// só pode existir uma rota padrão por aplicação no modo MVC
                //defaults: new { controller = "Teste", action = "IndexTeste", id = UrlParameter.Optional }
            );
        }
    }
}
