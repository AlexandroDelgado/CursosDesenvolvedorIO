using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaDemoMVC_5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC_5.Controllers
{
    [Route("")] // Rota amigavel
    [Route("Site")] // Rota amigavel
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("")] // Rota amigavel
        //[Route("Pagina-Inicial")] // Rota amigavel
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("")] // Rota amigavel
        [Route("Pagina-Inicial")] // Rota amigavel
        [Route("Pagina-Inicial/{id}/{categoria?}")] // Rota amigavel que recebe parametros
        public IActionResult Index(string id, string categoria)
        {
            return View();
        }

        [Route("Privacidade")] // Rota amigavel
        [Route("Politica-de-Privacidade")] // Rota amigavel
        public IActionResult Privacy()
        {
            return View();

            //// Teste de Action Result, retornando um script json.
            //return Json("{'Nome':'Alexandro'}");

            //// Teste de Action Result, retornando um arquivo txt.
            //var fileBytes = System.IO.File.ReadAllBytes(@"c:\arquivo.txt"); // Pede para ler todos os bytes de um arquivo que está em "c:\", através da biblioteca System.IO.File.
            //var fileName = "arquivo.txt"; // Seta o nome que será utilizado para download.
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName); // Retorna o arquivo para o browser através do "Return File"
            //                                                                                    // o qual está recebendo uma coleção de bytes pelo "FileBytes,
            //                                                                                    // informando qual será o tipo de dado a ser baixado através do
            //                                                                                    // "MediaTypeNames.Application.Octet" neste caso será interpretado
            //                                                                                    // como um octet-stream ou seja, uma transferência de arquivos, um download.
            //                                                                                    // "fileName" o nome do arquivo que estou passando, que poderia ser qualquer
            //                                                                                    // outro nome.

            //// Teste de Action Result, retornando um texto
            //return Content("Action Result");
        }

        [Route("Erro")] // Rota amigavel
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
