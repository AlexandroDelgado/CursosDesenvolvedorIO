using DevIO.Business.Models.Produtos;
using System.Data.Entity.ModelConfiguration;

namespace DevIO.Infra.Data.Mappings
{
    // Esse mapeamento e feito através do Fluent API que é representado através da classe EntityTypeConfiguration<>
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        // Construtor do mapeamento
        public ProdutoConfig()
        {
            // Mapeamento para a tabela
            HasKey(p => p.Id); // Mapea o id como chave primária

            Property(p => p.Nome) // Mapea o nome
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(200); // Informa o tamanho máximo

            Property(p => p.Descricao) // Mapea a descrição
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(1000); // Informa o tamanho máximo

            Property(p => p.Imagem) // Mapea a imagem
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(100); // Informa o tamanho máximo

            HasRequired(navigationPropertyExpression: p => p.Fornecedor) // Requer a configuração da propriedade de navegação(relacionamento) <Produto, Fornecedor>
                .WithMany(f => f.Produtos) // Dependente da configuração da propriedade de navegação <Produto> ("WithRequiredPrincipal" para um, "WithMany" para muitos ou "WithOptional" para opcional)
                .HasForeignKey(p => p.FornecedorId); // Define qual é a chave estrangeira <FornecedorID>

            ToTable("Produtos"); // Informa qual será o nome da tabela no banco de dados
        }
    }
}
