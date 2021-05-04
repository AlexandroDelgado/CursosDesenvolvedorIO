using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site
{
    // Declara��o da classe.
    public class Program
    {
        // M�todo que inicia a aplica��o executando o CreateHostBuilder.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); // Executa o m�todo CreateHostBuilder 
        }

        // Este m�todo � o que devolve o IHostBuilder (Web Host do ASP.Net - J� que o ASP.Net roda em cima do pr�prio processo).
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // Onde ele passa os argumentos.
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  // Utilizando o arquivo de Startup.
                });
    }
}
