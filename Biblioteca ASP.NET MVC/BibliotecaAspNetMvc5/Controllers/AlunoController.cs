using BibliotecaAspNetMvc5.Data;
using BibliotecaAspNetMvc5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaAspNetMvc5.Controllers
{
    // a classe está herdando um controller
    public class AlunoController : Controller
    {
        // cria o contexto para salvar no banco
        private readonly AppDbContext context = new AppDbContext();

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
            // caso o modelo esteja correto.
            if (ModelState.IsValid) 
            {
                // Atribui a data da matricula
                aluno.DataMatricula = DateTime.Now;

                // Adiciona o contexto na memória
                context.Alunos.Add(aluno);

                // salva o aluno no banco
                context.SaveChanges();

                // Retorna a instância do objeto para a View como verdeiro
                return View(aluno);
            }
            else
            {
                // retorna a instância do objeto para a view com falso
                return View(aluno);
            }
        }

        [HttpGet]
        [Route(template: "Obter-Alunos")]
        // Exibe uma lista com os alunos
        public ActionResult ObterAlunos()
        {
            // cria uma variavel com a lista de alunos
            var alunos = context.Alunos.ToList();

            // Retorna o primeiro aluno da lista
            return View("NovoAluno", model: alunos.FirstOrDefault());
        }

        [HttpGet]
        [Route("Editar-Aluno")]
        // edita o aluno
        public ActionResult EditarAluno()
        {
            // seleciona o primeiro aluno através do nome
            var aluno = context.Alunos.FirstOrDefault(a => a.Nome == "Andreia Medeiros Ramos");

            // atribui o novo nome para o aluno
            aluno.Nome = "Andréia Delgado";

            // cria uma variavel para ser salva no banco
            var entry = context.Entry(aluno);

            // adiciona o aluno ao contexto existente
            context.Set<Aluno>().Attach(aluno);

            // Modifica o aluno no contexto;
            entry.State = EntityState.Modified;

            // Salva o contexto
            context.SaveChanges();

            // Poderia enviar o objeto, porém esta obtendo o mesmo novamente
            var alunoNovo = context.Alunos.Find(aluno.Id);

            // retorna a view com o aluno novo
            return View("NovoAluno", model: alunoNovo);
        }

        [HttpGet]
        [Route("Excluir-Aluno")]
        // remove o aluno da base
        public ActionResult ExcluirAluno()
        {
            // Cria uma variavel com o aluno para exclusão
            var aluno = context.Alunos.FirstOrDefault(a => a.Nome == "Eduardo");

            // Remove o aluno atravé do seu objeto
            context.Alunos.Remove(aluno);

            // salva o contexto na base
            context.SaveChanges();

            // Recebe a nova lista de alunos
            var alunos = context.Alunos.ToList();

            // retorna o primeiro aluno da lista
            return View("NovoAluno", model: alunos.FirstOrDefault());
        }
    }
}