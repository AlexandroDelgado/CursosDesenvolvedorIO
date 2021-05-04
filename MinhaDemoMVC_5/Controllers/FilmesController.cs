using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC_2.Controllers.Filmes
{
    public class FilmesController : Controller
    {
        // Informa o verbo que entrega para o client
        [HttpGet]
        // Método de controle
        public IActionResult Adicionar()
        {
            // Retorna a view de mesmo nome
            return View();
        }
    }
}
