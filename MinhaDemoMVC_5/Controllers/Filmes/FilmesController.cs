using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC_5.Models;

namespace MinhaDemoMVC_5.Controllers.Filmes
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

        // Informa o verbo que entrega para o servidor
        [HttpPost]
        [AutoValidateAntiforgeryTokenAttribute]
        // Método de controle
        public IActionResult Adicionar(Filme filme)
        {
            // Verifica se é uma entidade válida
            if (ModelState.IsValid)
            {
                // ADICIONE UM PONTO DE INTERRUPÇÃO NA LINHA ACIMA PARA PODER TESTAR O MODELSTATE.ISVALID.
            }

            // Retorna a view de mesmo nome
            return View(filme);
        }
    }
}
