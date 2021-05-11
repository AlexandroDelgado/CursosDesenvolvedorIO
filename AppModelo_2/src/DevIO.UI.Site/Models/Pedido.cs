using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Models
{
    // Classe Pedido
    public class Pedido
    {
        // Propriedade da classe
        public Guid Id { get; set; }

        // Construtor do Método Pedidio
        public Pedido()
        {
            // Gera um novo id randomico
            Id = Guid.NewGuid();
        }
    }
}
