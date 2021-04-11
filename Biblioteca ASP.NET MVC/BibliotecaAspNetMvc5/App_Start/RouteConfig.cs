using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BibliotecaAspNetMvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Uma melhor forma de se fazer novas rotas é com o [routes(template:"NomeDaRota")] em cima do controler que você deseja usar.
            // [RoutePrefix("Teste")] deverá ser usado em cima da classe principal da pagina. Seta uma rota "Teste" para todos os controllers desta pagina. Não deve ser utilizado na HomeController.
            // [Route] utilizado para pegar a rota do RoutePrefix e utiliza como um controlador da pagina.
            // [Route(template: "Um-outro-teste")] seta o nome da rota recebendo o controller pelo RotaPrefix.
            // [Route(template: "Um-outro-teste")] Quando utilizado sem um RotaPrefix, fica sendo o nome da pagina
            // [Route(template: "Teste/Um-outro-teste")] define o novo nome de rota e pode ser utilizada com um controler imaginário exemplo [Route(template: "Novo-Controlador/Um-outro-teste")], onde o NovoControlador é um controller ficticio.

            // Trata as rotas que vieram dos controllers
            routes.MapMvcAttributeRoutes();

            // sempre colocar as rotas mais complexas por cima e testar muito bem para que não haja erro de navegação,
            // já que o processamento das rotas seguem uma regra de cima para baixo.

            routes.MapRoute(
                name: "Institucional",
                url: "Institucional/{controller}/{action}",
                defaults: new { controller = "Teste", action = "IndexTeste" }
            );

            routes.MapRoute(
                name: "Teste",
                url: "Sistema/{controller}/{action}/{id}",
                defaults: new { controller = "Teste", action = "IndexTeste", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

                //// só pode existir uma rota padrão por aplicação no modo mvc
                //defaults: new { controller = "Teste", action = "IndexTeste", id = UrlParameter.Optional }
            );
        }
    }
}
