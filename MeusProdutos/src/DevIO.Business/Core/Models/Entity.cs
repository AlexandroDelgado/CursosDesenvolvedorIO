using System;

namespace DevIO.Business.Core.Models
{
    // Essa é uma classe Abstract(mãe) que não pode ser instanciada apenas herdada.
    public abstract class Entity // Definida como sendo uma entidade
    {
        // Conceito de entidade: é aquela que possui valor único, como um CPF, ninguém pode ter um CPF igual, tranformando a entidade em algo identificavel.
        //      tudo que for uma entidade pode ser persistido no banco, tendo um id único para poder ser localizado. 
        //      E neste caso usamos o "Id = Guid.NewGuid();" como uma chave primária e não o CPF.

        // Construtor da entidade
        protected Entity() // Já que a classe vai ser herdada, os membros protegidos só podem ser acessiveis a quem herdar.
        {
            // Seta o id com um novo guid (Quase impossível de gerar um novo igual na mesma aplicação)
            Id = Guid.NewGuid();
        }
        
        // Propriedade
        public Guid Id { get; set; } // Tipo Guid não necessita de persistência no banco para definir um id
    }
}
