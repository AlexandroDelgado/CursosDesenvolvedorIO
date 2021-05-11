using DevIO.UI.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Data
{
    // A classe PedidoRepository está implementado a interface de IPedidoRepository
    public class PedidoRepository : IPedidoRepository
    {
        // Método obter pedido
        public Pedido ObterPedido()
        {
            // Cria uma nova instância de pedido
            return new Pedido();
        }
    }

    // Interface IPedidoRepository
    public interface IPedidoRepository
    {
        // Obtem o método ObterPendido, através da classe pedido
        Pedido ObterPedido();
    }
}
