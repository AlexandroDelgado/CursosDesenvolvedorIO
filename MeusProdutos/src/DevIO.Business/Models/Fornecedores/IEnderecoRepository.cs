using System;
using System.Threading.Tasks;
using DevIO.Business.Core.Data;

namespace DevIO.Business.Models.Fornecedores
{
    // Esta interface implementa o IRepository do tipo fornecedor.
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        // Neste repositório só existem métodos especificos para o fornecedor.

        // Obtem o endereço do fornecedor através do id do fornecedor
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
