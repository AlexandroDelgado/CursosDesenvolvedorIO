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
    // Declaração da classe
    public class Startup
    {
        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc() // Adiciona o serviço MVC
            .SetCompatibilityVersion(CompatibilityVersion.Latest); // Seta a compatibilidade da versão mais recente (recomendado pela microsoft)
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verifica qual o ambiente
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Utiliza o ambiente de desenvolvimento
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => // Define o sistema de rotas (procure não utilizar)
            {
                //endpoints.MapGet("/", async context => // Mapeando o contexto de forma assincrona
                //{
                //    await context.Response.WriteAsync("Hello World!"); // Mandando gravar na tela a string.
                //});

                // Define uma rota padrão
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
