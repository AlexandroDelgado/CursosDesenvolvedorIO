using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevIO.AppMVC.Models;
using DevIO.AppMVC.ViewModels;
using DevIO.Business.Models.Produtos;
using DevIO.Business.Models.Produtos.Services;
using DevIO.Infra.Data.Repository;
using DevIO.Business.Core.Notifications;
using AutoMapper;

namespace DevIO.AppMVC.Controllers
{
    public class ProdutosController : Controller
    {
        // Não iremos usar o Entity, mas sim repositório e serviço.

        // Usaremos o repositório para fazer Leitura
        private readonly IProdutoRepository _produtoRepository;
        // Usaremos para fazermos o serviço de persistencia no banco
        private readonly IProdutoService _produtoService;
        // Interface do tipo automapper
        private readonly IMapper _mapper;

        // Construtor
        public ProdutosController()
        {
            
        }

        // GET:
        [Route("Lista-De-Produtos")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            // Passa a lista de produtos para ser mapeada e entregue como uma coleção do viewModel
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos()));
        }

        // GET: Produtos/Details/5
        [Route("Dados-Do-Produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        [Route("Novo-Produto")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Novo-Produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                // faz o mapeamento do produtoViewModel e já adiciona o mesmo
                await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));
                
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Edit/5
        [Route("Editar-Produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            ProdutoViewModel produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar-Produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        // GET: Produtos/Delete/5
        [Route("Excluir-Produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [Route("Excluir-Produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }

            await _produtoService.Remover(id);

            return RedirectToAction("Index");
        }

        // Método privado com base no Id, que obtem o produto para não ter que ficar fazendo sempre o mapeamento
        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            // obtem os dados do produto e do fornecedor através do mapeamento
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));

            return produto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoRepository.Dispose();
                _produtoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
