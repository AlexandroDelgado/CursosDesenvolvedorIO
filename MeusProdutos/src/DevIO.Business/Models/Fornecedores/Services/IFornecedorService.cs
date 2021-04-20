using System;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores.Services
{
    // A interface está implementado a para poder fazer o Disposable
    public interface IFornecedorService : IDisposable
    {
        // O serviço só vai executar ações que modifiquem o estado da entidade

        // Os métodos serão assincronos
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);

        // O cadastro do endereço e feito com o cadastro do fornecedor, e só existe um endereço por fornecedor. Por isso só atualizamos o endereço
        Task AtualizarEndereco(Endereco endereco);

    }
}
