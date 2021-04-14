using System.Web;
using System.Web.Optimization;

namespace TesteMVC5
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // A opção setada como true, vai compilar os seus arquivos de bundle para produção, já a opção setada como false, não executa a otimização.
            // Isto também pode ser feito através do Web.config na opção: <compilation debug="true" targetFramework="4.6.1"/>
            
            //BundleTable.EnableOptimizations = true;

            // Cria os bundles para otimização de arquivos
            bundles.Add(new ScriptBundle("~/bundles/testes").Include(
                      "~/Scripts/teste1.js",
                      "~/Scripts/teste2.js"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
