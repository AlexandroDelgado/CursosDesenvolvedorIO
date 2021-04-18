using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Mappings;
using System.Data.Entity;

namespace DevIO.Infra.Data.Context
{
    // O MeuDbContext irá herdar de DbContext para transforma o mesmo no contexto do EntityFramework
    public class MeuDbContext : DbContext
    {
        // O contrutor herda da base a connecition string para conexão com o banco
        public MeuDbContext() : base(nameOrConnectionString: "DefaultConnection")
        { }

        // Mapeamento DbSet
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        // Cria os modelos no banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Adiciona as configurações dos mapeamentos
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
        }
    }
}
