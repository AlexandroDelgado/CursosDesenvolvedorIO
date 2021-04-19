using System;
using DevIO.Business.Models.Fornecedores;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    // Especializa um repositório genérico para uma classe especifica, além de implementar a interface para implementação de métodos que não estão previstos pelo repositório genérico.
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        // Método para obter o endereço pelo id do fornecedor
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            // Este método traz o endereço pelo id do fornecedor, já que o id do endereço é o mesmo id de fornecedor, por termos uma cardinalidade de 1 para 1
            return await ObterPorId(fornecedorId);
        }
    }
}
