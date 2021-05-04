using Microsoft.AspNetCore.Mvc; /*Referência da controller*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    // Herda da classe Controller
    public class HomeController : Controller
    {
        // Action para retornar a index
        public IActionResult Index()
        {
            return View();
        }
    }
}
