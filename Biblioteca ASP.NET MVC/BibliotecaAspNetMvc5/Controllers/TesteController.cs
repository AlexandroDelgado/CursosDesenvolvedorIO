using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaAspNetMvc5.Controllers
{
    // seta uma rota "Teste" para todos os controllers desta pagina. Não deve ser utilizado na HomeController.
    [RoutePrefix("Teste")]

    public class TesteController : Controller
    {
        // utilizado para pegar a rota do RoutePrefix e utiliza como um controlador da pagina.
        [Route]
        public ActionResult IndexTeste()
        {
            return View();
        }

        // informa o novo nome da rota
        [Route(template:"Um-outro-teste")]
        public ActionResult IndexTeste2()
        {
            return View("IndexTeste");
        }
    }
}