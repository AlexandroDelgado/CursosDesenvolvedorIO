using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDemoMVC_5.Models
{
    public class Filme
    {
        // Propriedades
        [Key]  // Define a chave primária
        public int Id { get; set; }

        [Display(Name = "Titulo:")] // Altera o nome do campo para exibição
        [Required(ErrorMessage = "O Campo título é obrigatório!")] // Campo obrigatório
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O titulo precisa ter entre 3 e 60 caracteres!")] // Tamanho minimo e máximo
        public string Titulo { get; set; }

        [Display(Name = "Data de lançamento:")] // Altera o nome do campo para exibição
        [Required(ErrorMessage = "O Campo data de lançamento é obrigatório!")]  // Campo obrigatório
        [DataType(DataType.Date, ErrorMessage = "Data inválida!")] // Valida data
        public DateTime DataLancamento { get; set; }

        // [A-Z] = A primeira letra tem de ser de A até Z maiúscula. 
        // [a-zA-Z\u00C0-\u00FF""'\w-] = Da segunda letra em diante pode ser minúscula ou maiúscula, aceitando ascentuações.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Gernero em formato inválido!")] // Expressão regular
        [Required(ErrorMessage = "O Campo Genero é obrigatório!")]  // Campo obrigatório
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O genero precisa ter entre 3 e 60 caracteres!")]  // Tamanho minimo e máximo
        [Display(Name = "Genero:")] // Altera o nome do campo para exibição
        public string Genero { get; set; }

        [Display(Name = "Valor:")] // Altera o nome do campo para exibição
        [Range(1, 1000, ErrorMessage = "Informe um valor entre R$ 1,00 e R$ 1,000.00 reais!")] // Permite apenas valores de 1 a 1000
        [Required(ErrorMessage = "O Campo Valor é obrigatório!")]  // Campo obrigatório
        [Column(TypeName = "decimal(18,2)")] // Define o tipo de campo no banco de dados, não é a forma mais correta de se fazer a definição no banco
        public decimal Valor { get; set; }

        [Display(Name = "Avaliação:")] // Altera o nome do campo para exibição
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somente números!")] // Expressão regular que permite apenas números de 0 até 5
        public int Avaliacao { get; set; }
    }
}
