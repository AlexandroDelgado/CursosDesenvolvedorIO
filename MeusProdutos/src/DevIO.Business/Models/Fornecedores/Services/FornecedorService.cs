using DevIO.Business.Core.Services;
using DevIO.Business.Models.Fornecedores.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores.Services
{
    // Essa classe herda de BaseService e implementa a interface
    public class FornecedorService : BaseService, IFornecedorService
    {
        // Cria as propriedades de interface
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        // Cria o construtor
        public FornecedorService(IFornecedorRepository fornecedorRepository, IEnderecoRepository enderecoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        // Metodo void(Task) que adiciona o fornecedor
        public async Task Adicionar(Fornecedor fornecedor)
        {
            // Caso avalidação da entidade falhe o método gera um return
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;
            
            // verifica se já existe um fornecedor
            if (await FornecedorExistente(fornecedor)) return;

            // aguarda a adição do entidade fornecedor no repositório
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        // Método atualizar fornecedor (na atualização não atualizo o endereco)
        public async Task Atualizar(Fornecedor fornecedor)
        {
            // Caso avalidação da entidade falhe o método gera um return
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            // verifica se já existe um fornecedor
            if (await FornecedorExistente(fornecedor)) return;

            // aguarda a adição do entidade fornecedor no repositório
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        // Exclui o fornecedor
        public async Task Remover(Guid id)
        {
            // Obtem o fornecedor, produtos e endereços
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            // Verifica se o fornecedor possui produtos
            if (fornecedor.Produtos.Any()) return;

            // verifica se o fornecedor possui endereço
            if (fornecedor.Endereco != null)
            {
                await _enderecoRepository.Remover(fornecedor.Endereco.Id);
            }

            // Remove o fornecedor
            await _fornecedorRepository.Remover(id);
        }

        // Atualiza o endereço
        public async Task AtualizarEndereco(Endereco endereco)
        {
            // Caso o endereço na exista retorna
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            // Atualiza o endereço
            await _enderecoRepository.Atualizar(endereco);
        }

        // Cria um método assincrono que verifica a existência de um fornecedor
        private async Task<bool> FornecedorExistente(Fornecedor fornecedor)
        {
            // Seta a variavel com o valor do método assincrono buscar, onde Documento seja igual a Documento e Id seja diferente de id 
            var fornecedorAtual = await _fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id);

            // Retorna verdadeiro caso seja encontrado algum elemento
            return fornecedorAtual.Any();
        }

        // Remove o objeto da mémoria
        public void Dispose()
        {
            // A ? é caso o ojeto não exista, ele não chama o método
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
