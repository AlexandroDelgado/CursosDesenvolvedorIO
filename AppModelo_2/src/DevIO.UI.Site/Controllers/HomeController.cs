using DevIO.UI.Site.Data;
using DevIO.UI.Site.Servicos;
using Microsoft.AspNetCore.Mvc; /*Referência da controller*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class homeController : Controller
    {
        // Define as propriedades.
        public OperacaoService OperacaoService1 { get; }
        public OperacaoService OperacaoService2 { get; }

        // Recebe duas injeção de dependência
        public homeController(OperacaoService operacaoService1, OperacaoService operacaoService2)
        {
            // 
            OperacaoService1 = operacaoService1;
            OperacaoService2 = operacaoService2;
        }

        // Método que retorna o resultado das instâncias.
        public string Index()
        {
            // Concatena o código para mostrar dados de ambas as instâncias para comparação
            return
                "Primeira instância: " + Environment.NewLine +
                OperacaoService1.Transient.OperacaoId + Environment.NewLine +
                OperacaoService1.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService1.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService1.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Segunda instância: " + Environment.NewLine +
                OperacaoService2.Transient.OperacaoId + Environment.NewLine +
                OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }
    }






    //// Herda da classe Controller
    //public class HomeController : Controller
    //{
    //    // Propriedade privada para a injeção de dependência.
    //    private readonly IPedidoRepository _pedidoRepository;

    //    // Construtor que recebe uma injeção de dependência dentro do controller
    //    public HomeController(IPedidoRepository pedidoRepository)
    //    {
    //        // Informamos que a proprieade privada recebe o conteúdo do tipo "pedidoRepository que informamos no construtor.
    //        _pedidoRepository = pedidoRepository;
    //    }

    //    // Action para retornar a index
    //    public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository)
    //    {
    //        // Acessa a propriedade Id, do método, atravé da injeção de dependência.
    //        var Id = _pedidoRepository.ObterPedido().Id;

    //        return View();
    //    }
    //}
}
