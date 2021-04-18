using DevIO.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores
{
    // Esta interface implementa o IRepository do tipo fornecedor.
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        // Neste repositório só existem métodos especificos para o fornecedor.

        // Retorna o fornecedor e o seu endereço, através do id. (Fazendo um select com join, ou seja uma pesquisa que não é própria para um ambiente genérico.
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);

        // Retorna o fornecedor, os produtos do fornecedor e o endereço dele.
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
