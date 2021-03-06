using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevIO.AppMVC.ViewModels
{
    public class ProdutoViewModel
    {
        // contrutor
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }

        // Propriedades
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Fornecedor:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid FornecedorId { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Nome { get; set; }

        [DisplayName("Descrição:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 1)]
        public string Descricao { get; set; }

        //[DisplayName("Imagem do Produto:")]
        //public  HttpPostedFileBase ImagemUpload { get; set; } // possui o binário da imagem
        public string Imagem { get; set; }

        [DisplayName("Valor:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public decimal Valor { get; set; }
        
        [ScaffoldColumn(false)] // não é carregada na view do formulário
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        //// Fornecedor que representa o produto
        //public FornecedorViewModel Fornecedor { get; set; }

        //// Coleção de fornecedores
        //public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}