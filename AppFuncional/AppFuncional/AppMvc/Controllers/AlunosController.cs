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
    // Obriga o usuário a se logar, para utilizar qualquer um dos métodos.
    // Você também poderá deixa-lo para todos e e liberar um método especifico através do : [AllowAnonymous].
    [Authorize] // Caso você adicione em cima de um método expecifico, apenas aquel método solicitará logon.

    // Herda a classe controller
    public class AlunosController : Controller
    {
        // Instância um objeto de conexão com o banco de dados
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // Informa o método a ser utilizado para envio
        [HttpGet]
        [AllowAnonymous] // libera esse método para vizualização de qualquer pessoa.
        [OutputCache(Duration = 1)] // Guarda o conteúdo em cache pelo tempo determinado e só volta a atualizar o conteúdo após concluir a definição em segundos.
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
        // Caso ocorra um erro expecifico neste caso de referência nula, ele redireciona o usuário para uma view especifica.
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "Erro")]
        // Desabilita a validação tanto da view, quanto do modelo
        [ValidateInput(enableValidation: true)] // Sendo True para validar e False para desabilitar
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        // Bind quer dizer que a classe Aluno a ser criada nessa action só poderá receber os atributos que estão no parametro include,
        // caso seja passado mais algum atributo será definido com nulo.
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Descricao,CPF,Ativo")] Aluno aluno)
        {
            // verifica se o objeto aluno está cadastrado corretamente
            if (ModelState.IsValid)
            {
                aluno.DataMatricula = DateTime.Now; // Informa a data atual como data de matricula
                db.Alunos.Add(aluno); // Adiciona o objeto ao Contexto da memória para ser salvo no banco
                await db.SaveChangesAsync(); // Salva o usuário no banco
                TempData["Mensagem"] = "Aluno cadastrado com sucesso"; // Cria uma passagem de dados que irá passar por outro método ou controler e persister até a leitura.
                return RedirectToAction("Index"); // Encaminha o usuário para a Lista de alunos.
            }

            // Retorna o aluno para a View de cadastro.
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

            ViewBag.Mensagem = "Não esqueça que esta ação é irreversível."; // Passa dados de uma controller para uma view sem precisar de uma model.
            
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,Descricao,CPF,Ativo")] Aluno aluno) 
        {
            // Verifica se o Modelo é valido
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.Entry(aluno).Property(a => a.DataMatricula).IsModified = false; // Impede a alteração da data de matricula
                await db.SaveChangesAsync();
                TempData["Mensagem"] = "Aluno cadastrado com sucesso"; // Cria uma variavel que irá persister até a leitura.
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
