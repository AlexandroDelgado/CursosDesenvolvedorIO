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
    // Declaração da classe.
    public class Program
    {
        // Método que inicia a aplicação executando o CreateHostBuilder.
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); // Executa o método CreateHostBuilder 
        }

        // Este método é o que devolve o IHostBuilder (Web Host do ASP.Net - Já que o ASP.Net roda em cima do próprio processo).
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // Onde ele passa os argumentos.
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  // Utilizando o arquivo de Startup.
                });
    }
}
