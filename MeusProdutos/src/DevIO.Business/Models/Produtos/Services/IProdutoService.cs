using System;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos.Services
{
    // A interface implementa o a interface para o disposable
    public interface IProdutoService : IDisposable
    {
        // Modifica as ações das entidades através do id do mesmo
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
