using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    public class TesteController : Controller
    {
        // Aceita qualquer tipo de ação
        public ActionResult IndexTeste()
        {
            return View();
        }
    }
}