﻿//using DevIO.UI.Site.Services;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DevIO.UI.Site.Controllers.TiposCiclosVidasHomeController
//{
//    // Herda da controler
//    public class TiposCiclosVidasHomeController : Controller
//    {
//        // Define as propriedades.
//        public OperacaoService OperacaoService1 { get; }
//        public OperacaoService OperacaoService2 { get; }

//        // Recebe duas injeção de dependência
//        public TiposCiclosVidasHomeController(OperacaoService operacaoService1, OperacaoService operacaoService2)
//        {
//            // 
//            OperacaoService1 = operacaoService1;
//            OperacaoService2 = operacaoService2;
//        }

//        [Route("TiposCiclosVidasHome")]
//        // Método que retorna o resultado das instâncias.
//        public string Index()
//        {
//            // Concatena o código para mostrar dados de ambas as instâncias para comparação
//            return
//                "Primeira instância: " + Environment.NewLine +
//                OperacaoService1.Transient.OperacaoID + Environment.NewLine +
//                OperacaoService1.Scoped.OperacaoID + Environment.NewLine +
//                OperacaoService1.Singleton.OperacaoID + Environment.NewLine +
//                OperacaoService1.SingletonInstance.OperacaoID + Environment.NewLine +

//                Environment.NewLine +
//                Environment.NewLine +

//                "Segunda instância: " + Environment.NewLine +
//                OperacaoService2.Transient.OperacaoID + Environment.NewLine +
//                OperacaoService2.Scoped.OperacaoID + Environment.NewLine +
//                OperacaoService2.Singleton.OperacaoID + Environment.NewLine +
//                OperacaoService2.SingletonInstance.OperacaoID + Environment.NewLine;

//        }
//    }
//}
