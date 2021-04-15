using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMVC5.Data;
using TesteMVC5.Models;

namespace TesteMVC5.Controllers
{
    // a classe está herdadno um controller
    public class AlunoController : Controller
    {
        // Cria o contexto para salvar no banco
        private readonly AppDbContext context = new AppDbContext();

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
            if (ModelState.IsValid)
            {
                // Atribui a data da matricula
                aluno.DataMatricula = DateTime.Now;

                // Adiciona o contexto na memória
                context.Alunos.Add(aluno);

                // salva o aluno no banco
                context.SaveChanges();

                // caso o aluno tenha sido preenchido corretamente, envia o objeto aluno com status de verdadeiro.
                return View(aluno);
            }
            else
            {
                // caso o aluno não tenha sido preenchido corretamente, retorna o aluno com status falso.
                return View(aluno);
            }
        }

        [HttpGet]
        [Route(template: "Obter-Alunos")]
        // exibe uma lista com os alunos
        public ActionResult ObterAlunos()
        {
            // Cria uma variavél com a lista de alunos
            var alunos = context.Alunos.ToList();

            // exibe o primeiro aluno da lista
            return View("NovoAluno", model: alunos.FirstOrDefault());
        }

        [HttpGet]
        [Route(template: "Editar-Aluno")]
        // edita o aluno
        public ActionResult EditarAluno()
        {
            // seleciona o primeiro aluno através do nome
            var aluno = context.Alunos.FirstOrDefault(a => a.Nome == "Andreia Medeiros Ramos");

            aluno.Nome = "Andreia Delgado";

            // cria uma variavel para ser salva no banco
            var entry = context.Entry(aluno);

            // adiciona o aluno ao contexto
            context.Set<Aluno>().Attach(aluno);

            // modifica o aluno no contexto
            entry.State = EntityState.Modified;

            // salva o contexto
            context.SaveChanges();

            // Poderia enviar o objeto, porém está obtendo o mesmo novamente
            //var alunoNovo = context.Alunos.FirstOrDefault(a => a.Nome == "Andreia Delgado");
            var alunoNovo = context.Alunos.Find(aluno.Id);

            return View("NovoAluno", model: alunoNovo);
        }

        [HttpGet]
        [Route(template: "Excluir-Aluno")]
        // exclui o aluno da base
        public ActionResult ExcluirAluno()
        {
            // Cria uma variavél com o aluno para exclusão
            var aluno = context.Alunos.FirstOrDefault(a => a.Nome == "Eduardo");

            // remove o aluno através do seu objeto
            context.Alunos.Remove(aluno);

            // salva o contexto na base
            context.SaveChanges();

            // recebe uma lista de alunos
            var alunos = context.Alunos.ToList();

            // exibe o primeiro aluno da lista
            return View("NovoAluno", model: alunos.FirstOrDefault());
        }
    }
}