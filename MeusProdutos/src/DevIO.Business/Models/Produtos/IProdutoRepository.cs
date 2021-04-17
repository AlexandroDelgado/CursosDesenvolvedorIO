using DevIO.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos
{
    // Esta interface implementa o IRepository do Produto.
    public interface IProdutoRepository : IRepository<Produto>
    {
        // Neste repositório só existem métodos especificos para os produtos.

        // Retorna uma lista de produtos por fornecedor
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);

        // Retorna uma lista de todos os produtos e fornecedores
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();

        // Retorna uma instância de produto por fornecedor
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
