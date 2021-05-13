using DevIO.UI.Site.Data;
using DevIO.UI.Site.Services;
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
            .SetCompatibilityVersion(CompatibilityVersion.Latest); // Seta a compatibilidade da versão mais recente (recomendado pela microsoft)

            // Resolução de dependeência para a class PedidoRepository (Através da interface IPedidoRepository, resolvemos e temos a instâna de PedidoRepository).
            services.AddTransient<IPedidoRepository, PedidoRepository>(); // É necessário sempre ter uma classe que interprete a intervace da classe que estamos declarando.

            // Declaração das injeções de dependência dos "Tipos de Ciclos de Vida" de cada uma.
            services.AddTransient<IOperacaoTransient, Operacao>(); // A instância é criada ao setar a operação
            services.AddScoped<IOperacaoScoped, Operacao>(); // A instância é criada ao setar a operação
            services.AddSingleton<IOperacaoSingleton, Operacao>(); // A instância é criada ao setar a operação
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));  // Já recebe uma instância pronta com o Id zerado que dura durante toda a aplicação, 
                                                                                          //    já que a aplicação já sobe com esse dado na memória do servidor de forma
                                                                                          //    alocada, sem a necessidade de uma pessoa chamar a aplicação para gerar uma
                                                                                          //    alocação, ao contrário, o mesmo já irá vir alocado.

            services.AddTransient<OperacaoService>(); // A instância é criada ao setar a operação
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verifica qual o ambiente
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Utiliza o ambiente de desenvolvimento
            }

            app.UseStaticFiles(); // Solicita que seja feita a entrega dos arquivos staticos(js, css...) para o browser.

            app.UseRouting();

            app.UseEndpoints(endpoints => // Define o sistema de rotas (procure não utilizar)
            {
                //endpoints.MapGet("/", async context => // Mapeando o contexto de forma assincrona
                //{
                //    await context.Response.WriteAsync("Hello World!"); // Mandando gravar na tela a string.
                //});

                // Rotas das Áreas - (:exists = só roteia a área, quando ela realmente existir e requer uma Home em cada área para navegação via url).
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //// Cria uma rota para cada área, não necessitando a criação de uma Home.
                //endpoints.MapAreaControllerRoute(name: "AreaProdutos", areaName: "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                //endpoints.MapAreaControllerRoute(name: "AreaVendas", areaName: "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

                // Define uma rota padrão
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
