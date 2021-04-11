using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaAspNetMvc5.Controllers
{
    [RoutePrefix("Parametro")]
    public class ParametroController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        // sobrecarga do método com renomeação da rota [(template:"{id:int}")]
        // onde o :int, só foi adicionado para que em caso de erro seja retornado o erro 404(Página não encontrada)
        // caso queira adicionar outra variavel, utilize o "/" exemplo [(template:"{id:int}/{texto:maxlength(50)}")]
        // e coloque a variavel "texto" dentro da composição do método.
        // no link a seguir você poderá verificar quais são os tipos de variaveis e valores aceitos por passagem de rota:
        // https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/#route-prefixes
        
        [Route(template:"{id:int}")]
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}