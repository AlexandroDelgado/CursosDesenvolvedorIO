﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
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
            // Liberar para quando for subir para a produção e alterar o nome da pasta no "Gerenciador de Soluções" de "Areas" para "Modulos".

            //// Limpa a convenção e aplica uma nova convenção de forma global para a area,
            ////  devido a alteração do nome de "Areas" para "Modulos".
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.AreaViewLocationFormats.Clear();
            //    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            //});

            services.AddMvc() // Adiciona o serviço MVC
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2); // Seta a compatibilidade da versão
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Verifica qual o ambiente
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Utiliza o ambiente de desenvolvimento
            }

            app.UseStaticFiles(); // Solicita que seja feita a entrega dos arquivos staticos(js, css...) para o browser.

            // Código substituido pelo comando MVC, app.UseMVC
            //app.Run(async (context) => // Roda o contexto de forma assincrona
            //{
            //    await context.Response.WriteAsync("Hello World!"); // Manda gravar na tela o conteúdo de string
            //});

            // Define uma rota padrão
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

                //// Rotas das Áreas - (:exists = só roteia a área, quando ela realmente existir e requer uma Home em cada área para navegação via url)
                //routes.MapRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                // Cria uma rota para cada área, não necessitando a criação de uma Home.
                routes.MapAreaRoute(name: "AreaProdutos", areaName: "Produtos", template: "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "AreaVendas", areaName: "Vendas", template: "Vendas/{controller=Pedidos}/{action=Index}/{id?}");
            });
        }
    }
}
