using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DevIO.Infra.Data.Context
{
    // O MeuDbContext irá herdar de DbContext para transforma o mesmo no contexto do EntityFramework
    public class MeuDbContext : DbContext
    {
        // O contrutor herda da base a connecition string para conexão com o banco
        public MeuDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {
            // Desabilita as configurações que geral alta carga de processamento da aplicação
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        // Mapeamento DbSet
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        // Cria os modelos no banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Não permite que o Entity crie tabelas no plural automaticamente
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Não permite que o Entity exclua registros de um para muitos automaticamente
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); // Não permite que o Entity exclua registros de muitos para muitos automaticamente

            modelBuilder.Properties<string>() // Configurando os campos do tipo string
                .Configure(p =>
                    p.HasColumnType("varchar") // Informa que todos os campos do tipo string serão varchar
                    .HasMaxLength(100)); // do tamanho máximo de 100 caracteres.

            // Adiciona as configurações dos mapeamentos, que irão sobreescrever qualquer configuração acima.
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());

            // Executa todas as configurações do banco
            base.OnModelCreating(modelBuilder);
        }
    }
}
