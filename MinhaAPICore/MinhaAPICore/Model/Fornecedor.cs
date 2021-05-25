using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaAPICore.Model
{
    public class Fornecedor
    {
        [Key] // Define uma chave
        public Guid Id { get; set; } // Propriedade

        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Informa obrigatoriedade do campo
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)] // Informa o tamanho do campo
        public string Nome { get; set; } // Propriedade

        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Informa obrigatoriedade do campo
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)] // Informa o tamanho do campo
        public string Documento { get; set; } // Propriedade

        public int TipoFornecedor { get; set; } // Propriedade

        public bool Ativo { get; set; } // Propriedade
    }
}