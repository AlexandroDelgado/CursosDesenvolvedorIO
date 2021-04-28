using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Context;

namespace DevIO.Infra.Data.Repository
{
    // Especializa um repositório genérico para uma classe especifica, além de implementar a interface para implementação de métodos que não estão previstos pelo repositório genérico.
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        // Faz a injeção de dependência passando a mesma para a classe base sempre deverá criar a injeção de dependência na classe especializada, e não na classe base
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        // Método obter um produto e fornecedor
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {

            return await Db.Produtos.AsNoTracking() // Não precisa de persistência
                .Include(f => f.Fornecedor) // faz um include no fornecedor
                .FirstOrDefaultAsync(p => p.Id == id); // Onde o id do produto seja igual ao id do produto
        }

        // Método obter todos os produtos e fornecedores
        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking() // Não precisa de persistência
                    .Include(f => f.Fornecedor) // faz um include no fornecedor
                    .OrderBy(p => p.Nome) // ordeno os produtos por nome
                    .ToListAsync(); // retorno uma lista com todos os produtos e fornecedores
        }

        // Método obter todos os produtos por fornecedores
        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            // Chama o método direto, já que está passando o id do fornecedor
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
