using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevIO.AppMVC.ViewModels
{
    public class FornecedorViewModel
    {
        // Costrutor
        public FornecedorViewModel()
        {
            Id = Guid.NewGuid();
        }

        // propriedades
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Nome { get; set; }

        [DisplayName("Documento:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("Tipo:")]
        public int Tipo { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        [DisplayName("Nome:")]
        public bool Ativo { get; set; }

        //// Coleção com os produtos
        //public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}