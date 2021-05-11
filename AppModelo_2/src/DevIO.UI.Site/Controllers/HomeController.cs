using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Mvc; /*Referência da controller*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    // Herda da classe Controller
    public class HomeController : Controller
    {
        // Propriedade privada para a injeção de dependência.
        private readonly IPedidoRepository _pedidoRepository;

        // Construtor que recebe uma injeção de dependência dentro do controller
        public HomeController(IPedidoRepository pedidoRepository)
        {
            // Informamos que a proprieade privada recebe o conteúdo do tipo "pedidoRepository que informamos no construtor.
            _pedidoRepository = pedidoRepository;
        }

        // Action para retornar a index
        public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository)
        {
            // Acessa a propriedade Id, do método, atravé da injeção de dependência.
            var Id = _pedidoRepository.ObterPedido().Id;

            return View();
        }
    }
}
