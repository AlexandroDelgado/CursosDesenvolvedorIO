using DevIO.Business.Models.Fornecedores;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using DevIO.Infra.Data.Context;

namespace DevIO.Infra.Data.Repository
{
    // Especializa um repositório genérico para uma classe especifica, além de implementar a interface para implementação de métodos que não estão previstos pelo repositório genérico.
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        // Faz a injeção de dependência passando a mesma para a classe base sempre deverá criar a injeção de dependência na classe especializada, e não na classe base
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        // Método ascincrono que obtem o endereço de um fornedor
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            // Retornar o endereço do fornecedor
            return await Db.Fornecedores.AsNoTracking() // Não quero persistência
                .Include(f => f.Endereco) // Join onde o f de Fornecedor vai para f.Endereço / ou seja inclua o endereço
                .FirstOrDefaultAsync(f => f.Id == id); // apesar de ser uma lista, só vai existir um unico endereço.
        }

        // Método que retorna além do fornecedor e endereço, os seus produtos
        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            // Retornar o endereço do fornecedor
            return await Db.Fornecedores.AsNoTracking() // Não quero persistência
                .Include(f => f.Endereco) // Join onde o f de Fornecedor vai para f.Endereço / ou seja inclua o endereço
                .Include(f => f.Produtos) // Join onde o f de Fornecedor vai para f.Produtos / ou seja inclua todos os seus produtos
                .FirstOrDefaultAsync(f => f.Id == id); // Onde fornecedor seja igual ao id
        }

        //// Sobrescrevendo o método Remover. (não será utilizado)
        //public override async Task Remover(Guid id)
        //{
        //    // seta um fornecedor
        //    var fornecedor = await ObterPorId(id);

        //    // Altera o status do fornecedor
        //    fornecedor.Ativo = false;

        //    // Atualiza o status do fornecedor
        //    await Atualizar(fornecedor);
        //}
    }
}
