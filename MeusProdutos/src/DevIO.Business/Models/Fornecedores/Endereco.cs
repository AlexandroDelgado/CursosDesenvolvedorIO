using DevIO.Business.Core.Models;

namespace DevIO.Business.Models.Fornecedores
{
    // Essa classe também é uma entidade pois está herdando de entidade.
    public class Endereco : Entity
    {
        // Propriedades
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; } // Criar um objeto chamado Estado que possua, o nome a sigla, a coleção de cidades, para como uma melhoria remover as propriedades Cidade.

        /* Entity Framework - Relacionamento */
        public Fornecedor Fornecedor { get; set; } // Utilizado aqui por que o EF não deixa utilizar o Id do fornecedor
    }
}
