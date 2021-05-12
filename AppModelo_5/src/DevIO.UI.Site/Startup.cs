using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
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
            // Liberar para quando for subir para a produ��o e alterar o nome da pasta no "Gerenciador de Solu��es" de "Areas" para "Modulos".

            //// Limpa a conven��o e aplica uma nova conven��o de forma global para a area,
            ////  devido a altera��o do nome de "Areas" para "Modulos".
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.AreaViewLocationFormats.Clear();
            //    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            //});

            services.AddMvc() // Adiciona o servi�o MVC
            .SetCompatibilityVersion(CompatibilityVersion.Latest); // Seta a compatibilidade da vers�o mais recente (recomendado pela microsoft)

            // Resolu��o de depende�ncia para a class PedidoRepository (Atrav�s da interface IPedidoRepository, resolvemos e temos a inst�na de PedidoRepository).
            services.AddTransient<IPedidoRepository, PedidoRepository>(); // � necess�rio sempre ter uma classe que interprete a intervace da classe que estamos declarando.

            // 
            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
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

                // Rotas das �reas - (:exists = s� roteia a �rea, quando ela realmente existir e requer uma Home em cada �rea para navega��o via url).
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //// Cria uma rota para cada �rea, n�o necessitando a cria��o de uma Home.
                //endpoints.MapAreaControllerRoute(name: "AreaProdutos", areaName: "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                //endpoints.MapAreaControllerRoute(name: "AreaVendas", areaName: "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

                // Define uma rota padr�o
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
