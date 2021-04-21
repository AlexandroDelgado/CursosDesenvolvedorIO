using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevIO.AppMVC.ViewModels
{
    public class EnderecoViewModel
    {
        // Construtor
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }

        // Propriedades
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Logradouro:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Logradouro { get; set; }

        [DisplayName("Número:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(5, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} números!", MinimumLength = 1)]
        public string Nome { get; set; }

        [DisplayName("Complemento:")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 1)]
        public string Complemento { get; set; }

        [DisplayName("Bairro:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Bairro { get; set; }

        [DisplayName("CEP:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 8)]
        public string CEP { get; set; }

        [DisplayName("Cidade:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Cidade { get; set; }

        [DisplayName("Estado:")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Estado { get; set; }

        // Esconde a visualização do campo no formulário
        [HiddenInput]
        public Guid FornecedorId { get; set; }
    }
}