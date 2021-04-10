using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaAspNetMvc5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // VENDO ALGUNS CONTROLERS (Você pode usar um controle referência "ActionResult" ou forçar a nomenclatura do mesmo "RedirectResult", o que é mais indicado.)
        // rode a aplicação e coloque os controlers após o local/home/ContentResult para poder testar

        // Escreve o resultado na tela
        public ContentResult ContentResult()
        {
            return Content("Olá");
        }

        // Permite o download de arquivos
        public FileContentResult FileContentResult()
        {
            // ESTE TRECHO DE CÓDIGO ESTÁ ERRADO
            //var foto:byte[] = System.IO.File.ReadAllBytes(Server.MapPath("/content/images/capa.png"));
            var foto = System.IO.File.ReadAllBytes(Server.MapPath("/content/images/capa.png"));
            return File(foto, contentType: "image/png", fileDownloadName: "capa.png");
        }

        // Retorna uma instâncida(new) da classe com o erro de não autorizado
        public HttpUnauthorizedResult HttpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult();
        }

        // Retorna um Resultado de um Json
        public JsonResult JsonResult()
        {
            // Por proteção o ASP.Net MVC não permite que seja feito um GET(retorno) de um método que retorna json, é necessário permitir através do JsonRequestBehavior.AllowGet.
            return Json(data: "teste:'Teste'", JsonRequestBehavior.AllowGet);
        }

        // Retorna uma instâncida(new) da classe com o  resultado de redirecionamento da url.
        public RedirectResult RedirectResult()
        {
            return new RedirectResult(url: "https://desenvolvedor.io");
        }

        // Retorna um redirecionamento para uma view especifica no sistema
        public RedirectToRouteResult RedirectToRouteResult()
        {
            //// recebe um objeto anônimo, utiliado para rotas mais especificas
            //return RedirectToRoute(new
            //{
            //    Controller = "Teste",
            //    action = "IndexTeste"
            //});

            // redireciona para rotas mais simples
            return RedirectToAction("IndexTeste", controllerName: "Teste");
        }

    }
}