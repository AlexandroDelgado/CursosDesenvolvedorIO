using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteMVC5.Models
{
    public class Aluno
    {
        // DataAnnotations: são as validações dos dados que são feitas na models, através de um processo chamado: ModelBind.

        [Key]
        public int Id { get; set; }

        [DisplayName("Nome Completo*")]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres!")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Nome { get; set; }
       
        [DisplayName("E-mail*")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
       
        [DisplayName("CPF*")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string CPF { get; set; }
        
        public DateTime DataMatricula { get; set; }
        
        public bool Ativo { get; set; }

        //[Required(ErrorMessage = "O campo {0} é requerido")]
        //public string Senha { get; set; }

        //[Compare(otherProperty:"Senha", ErrorMessage = "As senha informadas não conferem")]
        //[Required(ErrorMessage = "O campo {0} é requerido")]
        //public string SenhaConfirmacao { get; set; }
    }
}