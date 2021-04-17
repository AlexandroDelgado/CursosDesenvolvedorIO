using System;
using DevIO.Business.Core.Models;
using DevIO.Business.Models.Fornecedores;

namespace DevIO.Business.Models.Produtos
{
    // A classe produto está herdando a classe pai Entity (Tranformando ela em uma entidade, já que está herdando de uma entidade).
    public class Produto : Entity
    {
        // Propriedades
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* Entity Framework - Relacionamento */
        public Fornecedor Fornecedor { get; set; } // Utilizado aqui por que o EF não deixa utilizar o Id do fornecedor
    }
}
