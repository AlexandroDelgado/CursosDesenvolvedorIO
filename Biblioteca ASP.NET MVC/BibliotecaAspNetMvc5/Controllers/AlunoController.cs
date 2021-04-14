using BibliotecaAspNetMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaAspNetMvc5.Controllers
{
    // a classe está herdando um controller
    public class AlunoController : Controller
    {
        /*
            [HttpGet] Declara o tipo do verbo. Quando retornarmos a view de forma vazia o correto é usar o GET e POST quando preenchido.
            [Route(template: "Novo-Aluno")] Cria a rota para navegação em url.
        */
        [HttpGet]
        [Route(template: "Novo-Aluno")]
        // A ActionResult, está fazendo a parte de contrutor da classe
        public ActionResult NovoAluno()
        {
            // Instância a view com o valor em branco para um novo cadastro
            return View();
        }

        // Valida o token recebido da view para evitar ataques do tipo CSRF(Cross-site request forgery) entre outros.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(template: "Novo-Aluno")]
        // A ActionResult verifica se retorna o objeto aluno como verdadeiro ou falso para a View 
        public ActionResult NovoAluno(Aluno aluno) 
        {
            // caso o modelo esteja correto, retorna o objeto aluno para a view informando que está correto.
            if (!ModelState.IsValid) 
            {
                // Retorna a instância do objeto para a View como verdeiro
                return View(aluno);
            }
            else
            {
                // retorna a instância do objeto para a view com falso
                return View(aluno);
            }
        }
    }
}