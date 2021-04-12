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
        // cria a rota para navegação em url que simulara o recebimento de uma instância "aluno" para o método "Novo".
        [Route(template:"Novo-Aluno")]

        // A ActionResult está simulando a entrada de um novo aluno
        // isto está sendo feito por não ter sido emprementado a view ainda.
        public ActionResult Novo(Aluno aluno)
        {
            // simula a criação da instância de um aluno
            aluno = new Aluno
            {
                // popula os dados do aluno para teste
                Id = 1,
                Nome = "Eduardo", // passe o nome vazio
                CPF = "12345678912",
                DataMatricula = DateTime.Now,
                Email = "edu@edu.com", // troque a @ por 2
                Ativo = true
            };

            // passa o objeto modelo(aluno) para a action Index.
            return RedirectToAction("Index", aluno);
        }

        // Essa action está sendo criada para validar a passagem do aluno
        public ActionResult Index(Aluno aluno)
        {
            // caso o modelo esteja correto, retorna o objeto aluno para a view informando que está correto.
            if (!ModelState.IsValid) return View(aluno);

            // Devolve o objeto aluno com erro
            return View(aluno);
        }

    }
}