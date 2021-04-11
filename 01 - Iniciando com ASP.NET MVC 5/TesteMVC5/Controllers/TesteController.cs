using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    // seta uma rota testes para todos os controllers teste (não colocar o RoutePrefix na HomeController)
    [RoutePrefix("Testes")]
    public class TesteController : Controller
    {
        [Route]
        // Aceita qualquer tipo de ação
        public ActionResult IndexTeste()
        {
            return View();
        }

        [Route(template: "Um-outro-teste")]
        // Aceita qualquer tipo de ação
        public ActionResult IndexTeste2()
        {
            return View("IndexTeste");
        }
    }
}