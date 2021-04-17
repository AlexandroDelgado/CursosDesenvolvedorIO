using System.Collections.Generic;
using DevIO.Business.Core.Models;
using DevIO.Business.Models.Produtos;

namespace DevIO.Business.Models.Fornecedores
{
    // A classe fornecedor está herdando a classe pai Entity (Tranformando ela em uma entidade, já que está herdando de uma entidade).
    public partial class Fornecedor : Entity
    {
        // Propriedades
        public string Nome { get; set; }
        public string Documento { get; set; } // Poderia ser um objeto de valor, chamado documento (Pesquisar sobre objetos de valor C#).
        public TipoFornecedor TipoFornecedor { get; set; } // Esta propriedade é do tipo enum
        public Endereco Endereco { get; set; } // Objeto complexo. São uma representação de uma entidade.
        public bool Ativo { get; set; }

        /* Entity Framework - Relação */
        public ICollection<Produto> Produtos { get; set; } // Essa coleção, é uma relação com o entity framework por que ele irá trazer os produtos da base. ICollection permite a inclusão de produtos.
    }
}
