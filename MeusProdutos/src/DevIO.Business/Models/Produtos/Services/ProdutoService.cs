using DevIO.Business.Core.Notifications;
using DevIO.Business.Core.Services;
using DevIO.Business.Models.Produtos.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos.Services
{
    // A classe herda da classe BaseService e implementa a interface IProdutoService
    public class ProdutoService : BaseService, IProdutoService
    {
        // Define a interface do repositório de produto
        private readonly IProdutoRepository _produtoRepository;
        
        // Cria o construtor da classe com a injeção de dependência do repositorio
        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        // Método Adicionar de forma assincrona
        public async Task Adicionar(Produto produto)
        {
            // Verifica se o produto é válido.
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            // Persiste a entidade produto
            await _produtoRepository.Adicionar(produto);
        }

        // Método Atualizar de forma assincrona
        public async Task Atualizar(Produto produto)
        {
            // Verifica se o produto é válido.
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            // Persiste a entidade produto
            await _produtoRepository.Atualizar(produto);
        }

        // Método Remover de forma assincrona
        public async Task Remover(Guid id)
        {
            // Remove o produto através do seu id
            await _produtoRepository.Remover(id);
        }

        // Limpa a memória
        public void Dispose()
        {
            // ? verifica se o repositório possui uma instânca
            _produtoRepository?.Dispose();
        }
    }
}
