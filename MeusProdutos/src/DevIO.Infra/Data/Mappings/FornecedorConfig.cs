using DevIO.Business.Models.Fornecedores;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DevIO.Infra.Data.Mappings
{
    // Esse mapeamento e feito através do Fluent API que é representado através da classe EntityTypeConfiguration<>
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        // Construtor do mapeamento
        public FornecedorConfig()
        {
            // Mapeamento para a tabela
            HasKey(f => f.Id); // Mapea o id como chave primária

            Property(f => f.Nome) // Mapea o nome do fornecedor
                .IsRequired() // Informa que é obrigatório
                .HasMaxLength(200); // Informa o tamanho máximo

            Property(f => f.Documento) // mapea o documento do fornecedor
                .IsRequired() // Informa que é obrigatório
                .HasMaxLength(14) // Informa o tamanho máximo
                .HasColumnAnnotation(name: "IX_Documento", value: new IndexAnnotation(
                        new System.ComponentModel.DataAnnotations.Schema.IndexAttribute { IsUnique = true })); // Cria um indice na tabela no banco de dados
            
            HasRequired(navigationPropertyExpression: f => f.Endereco) // Informa que o fornecedor tem um endereço requerido (Caso não fosse obrigatório, poderia ser usado o HasOptional<>)
                .WithRequiredPrincipal(navigationPropertyExpression: e => e.Fornecedor); // informa que o principal nesta relação é o fornecedor

            ToTable("Fornecedores"); // Informa qual será o nome da tabela no banco de dados

        }
    }
}
