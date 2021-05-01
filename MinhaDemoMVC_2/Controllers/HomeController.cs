﻿using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC_2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC_2.Controllers
{
    [Route("")] // Rota amigavel
    [Route("Site")] // Rota amigavel
    public class HomeController : Controller
    {
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
        }

        [Route("Erro")] // Rota amigavel
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
