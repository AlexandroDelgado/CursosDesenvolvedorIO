using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Areas.Produtos.Controllers
{
    // Define a rota para Cadastro Produtos
    [Area("Produtos")] // Informe conforme descrito na pasta.
    [Route("Produtos")] // Adiciona uma rota
    public class CadastroController : Controller
    {
        [Route("Lista")] // Adiciona uma rota
        public IActionResult Index()
        {
            return View();
        }

        // Rota para simplificar a busca
        [Route("Busca")] // Adiciona uma rota
        public IActionResult Busca()
        {
            return View();
        }
    }
}
