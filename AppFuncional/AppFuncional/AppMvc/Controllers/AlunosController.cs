using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMvc.Models;

namespace AppMvc.Controllers
{
    // Herda a classe controller
    public class AlunosController : Controller
    {
        // Instância um objeto de conexão com o banco de dados
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // Informa o método a ser utilizado para envio
        [HttpGet]
        // cria a rota para a lista de alunos
        [Route(template: "Listar-Alunos")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Alunos.ToListAsync());
        }

        // Informa o método a ser utilizado para envio
        [HttpGet]
        // cria a rota para o detalhe do aluno
        [Route(template: "Aluno-Detalhe/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);
            
            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        // Informa o método a ser utilizado para envio
        [HttpGet]
        // cria a rota para o novo aluno
        [Route(template: "Novo-Aluno")]
        public ActionResult Create()
        {
            return View();
        }

        // Informa o método a ser utilizado para envio
        [HttpPost]
        // cria a rota para a lista de alunos
        [Route(template: "Novo-Aluno")]
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        // Bind quer dizer que a classe Aluno a ser criada nessa action só poderá receber os atributos que estão no parametro include,
        // caso seja passado mais algum atributo será definido com nulo.
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,CPF,DataMatricula,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // Informa o método a ser utilizado para envio
        [HttpGet]
        // cria a rota para a lista de alunos
        [Route(template: "Editar-Aluno/{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);
            
            if (aluno == null)
            {
                return HttpNotFound();
            }
            
            return View(aluno);
        }

        // Informa o método a ser utilizado para envio
        [HttpPost]
        // cria a rota para a lista de alunos
        [Route(template: "Editar-Aluno/{id:int}")]
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        // Bind quer dizer que a classe Aluno a ser criada nessa action só poderá receber os atributos que estão no parametro include,
        // caso seja passado mais algum atributo será definido com nulo.
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,CPF,DataMatricula,Ativo")] Aluno aluno) 
        {
            // Verifica se o Modelo é valido
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // Informa o método a ser utilizado para envio
        [HttpGet]
        // cria a rota para a lista de alunos
        [Route(template: "Excluir-Aluno/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);
            
            if (aluno == null)
            {
                return HttpNotFound();
            }
            
            return View(aluno);
        }

        // Informa o método a ser utilizado para envio
        [HttpPost]
        // cria a rota para a lista de alunos
        [Route(template: "Excluir-Aluno/{id:int}")]
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);
            db.Alunos.Remove(aluno);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Limpa o context da memória
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
