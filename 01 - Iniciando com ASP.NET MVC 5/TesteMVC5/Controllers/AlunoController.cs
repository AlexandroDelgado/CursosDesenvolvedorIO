using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC5.Models;

namespace TesteMVC5.Controllers
{
    // a classe está herdadno um controller
    public class AlunoController : Controller
    {
        // Declara o tipo de verbo. Quando retornarmos a view de forma vazia o correto é usar o Get
        [HttpGet]
        // cria a rota para navegação em url que simulara o recebimento de uma instância "aluno" para o método "Novo".
        [Route(template: "Novo-Aluno")]

        public ActionResult NovoAluno()
        {
            return View();
        }

        // Declara o tipo de verbo. Quando retornarmos a view de forma preenchida, o correto é usar o Post
        [HttpPost]
        // Valida o token recebido da view para evitar ataques do tipo CSRF(Cross-site request forgery) entre outros
        [ValidateAntiForgeryToken]
        // cria a rota para navegação em url que simulara o recebimento de uma instância "aluno" para o método "Novo".
        [Route(template: "Novo-Aluno")]
        // Executa a actionResult para o objeto aluno
        public ActionResult NovoAluno(Aluno aluno)
        {
            // Verifica o estado do aluno
            if (!ModelState.IsValid)
            {
                // Neste ponto colocariamos as nossas regras de negócio e salvariamos no banco.

                return View(aluno); // caso o aluno tenha sido preenchido corretamente, envia o objeto aluno com status de verdadeiro.
            }
            else
            {
                return View(aluno); // caso o aluno não tenha sido preenchido corretamente, retorna o aluno com status falso.
            }
        }
    }
}