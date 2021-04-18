using DevIO.Business.Models.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace DevIO.Infra.Data.Mappings
{
    // Esse mapeamento e feito através do Fluent API que é representado através da classe EntityTypeConfiguration<>
    public class EnderecoConfig : EntityTypeConfiguration<Endereco> 
    {
        // Construtor do mapeamento
        public EnderecoConfig()
        {
            // Mapeamento para a tabela
            HasKey(f => f.Id); // Mapea o id como chave primária

            Property(c => c.Logradouro) // Mapea o logradoruro
                // .HasColumnName("Rua") // Suponhamos que você já tenha uma tabela no banco e o nome do campo esteja como Rua.
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(200); // Informa o tamanho máximo

            Property(c => c.Numero) // Mapea o número
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(5); // Informa o tamanho máximo

            Property(c => c.Cep) // Mapea o cep
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(8) // Informa o tamanho máximo
                .IsFixedLength(); // Informa que o tamanho é fixo, ou seja sempre vai ser 8, igual a um char(8).

            Property(c => c.Complemento) // Mapea o complemento
                .HasMaxLength(250); // Informa o tamanho máximo

            Property(c => c.Bairro) // Mapea o bairro
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(100); // Informa o tamanho máximo

            Property(c => c.Cidade) // Mapea a cidade
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(100); // Informa o tamanho máximo

            Property(c => c.Estado) // Mapea o estado
                .IsRequired() // informa que é obrigatório
                .HasMaxLength(100); // Informa o tamanho máximo

            ToTable("Enderecos"); // Informa qual será o nome da tabela no banco de dados
        }
    }
}
