using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site
{
    // Declara��o da classe
    public class Startup
    {
        // Este m�todo � chamado pelo tempo de execu��o. Use este m�todo para adicionar servi�os ao cont�iner.
        // Para obter mais informa��es sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc() // Adiciona o servi�o MVC
            .SetCompatibilityVersion(CompatibilityVersion.Latest); // Seta a compatibilidade da vers�o mais recente (recomendado pela microsoft)
        }

        // Este m�todo � chamado pelo tempo de execu��o. Use este m�todo para configurar o pipeline de solicita��o HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verifica qual o ambiente
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Utiliza o ambiente de desenvolvimento
            }

            app.UseStaticFiles(); // Solicita que seja feita a entrega dos arquivos staticos(js, css...) para o browser.

            app.UseRouting();

            app.UseEndpoints(endpoints => // Define o sistema de rotas (procure n�o utilizar)
            {
                //endpoints.MapGet("/", async context => // Mapeando o contexto de forma assincrona
                //{
                //    await context.Response.WriteAsync("Hello World!"); // Mandando gravar na tela a string.
                //});

                // Rotas das �reas - (:exists = s� rotea a �rea, quando ela realmente existir)
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                // Define uma rota padr�o
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
