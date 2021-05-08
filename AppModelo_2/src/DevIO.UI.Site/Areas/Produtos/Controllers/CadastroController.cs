using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Areas.Produtos.Controllers
{
    // Define a rota para Cadastro Produtos
    [Area("Produtos")] // Informe conforme descrito na pasta.
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
