using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMvc.Models
{
    public class Aluno
    {
        // Define as propriedades
        [Key] // Define o campo como chave primária
        public int Id { get; set; }

        [DisplayName("Nome Completo*")] // Informa o nome do campo para exibição
        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Obriga o preenchimento do mesmo
        [MinLength(7, ErrorMessage = "O campo {0} não aceita menos que 7 caractéres")] // Define o tamanho máximo de caracteres
        [MaxLength(80, ErrorMessage = "O campo {0} não aceita mais que 80 caractéres")] // Define o tamanho máximo de caracteres
        public string Nome { get; set; }

        [DisplayName("E-mail")] // Informa o nome do campo para exibição
        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Obriga o preenchimento do mesmo
        [MinLength(6, ErrorMessage = "O campo {0} não aceita menos que 6 caractéres")] // Define o tamanho máximo de caracteres
        [MaxLength(254, ErrorMessage = "O campo {0} não aceita mais que 254 caractéres")] // Define o tamanho máximo de caracteres
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")] // Válida o e-mail
        public string Email { get; set; }

        [DisplayName("CPF")] // Informa o nome do campo para exibição
        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Obriga o preenchimento do mesmo
        [MinLength(14, ErrorMessage = "O campo {0} deve ter 14 caractéres, entre números e pontuação")] // Define o tamanho máximo de caracteres
        [MaxLength(14, ErrorMessage = "O campo {0} deve ter 14 caractéres, entre números e pontuação")] // Define o tamanho máximo de caracteres
        public string CPF { get; set; }

        [DisplayName("Data da Matricula")] // Informa o nome do campo para exibição
        [Required(ErrorMessage = "O campo {0} é obrigatório")] // Obriga o preenchimento do mesmo
        public DateTime DataMatricula { get; set; }

        [DisplayName("Ativo")]  // Obriga o preenchimento do mesmo
        public bool Ativo { get; set; }
    }
}