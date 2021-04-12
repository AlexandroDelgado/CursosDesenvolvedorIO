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
        // cria a rota para teste de navegação em url que simulara o recebimento de uma isntância "aluno" para o método "Novo".
        [Route(template:"Novo-Aluno")]

        // A actionResult está simulando a entrada de um novo aluno
        // isto está sendo feito por não ter sido emprementado a view ainda.
        public ActionResult Novo(Aluno aluno)
        {
            // instância de um aluno
            aluno = new Aluno
            {
                // popula as propriedades do aluno para teste
                Id = 1,
                Nome = "", // passe o nome vazio
                CPF = "12345678912",
                DataMatricula = DateTime.Now,
                Email = "alexandrodelgado0hotmail.com", // troque a @ por 0
                Ativo = true
            };

            // passa o objeto Modelo(aluno) para a actionResult index, que validára o novo aluno.
            return RedirectToAction("Index", aluno);
        }

        // essa action está sendo criada para a validação do objeto aluno
        public ActionResult Index(Aluno aluno) 
        {
            // caso o modelo esteja correto, retorna o objeto aluno para a view informando que está correto.
            if (!ModelState.IsValid) return View(aluno);

            // devolve o objeto para a view aluno com os parâmetros de erro criados na model aluno.
            return View(aluno);
        }
    }
}