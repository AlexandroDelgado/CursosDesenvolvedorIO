using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC_2.Data;


namespace MinhaDemoMVC_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Adiciona o MVC e seta a versão de compatibilidade
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MinhaDemoMVC_2Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MinhaDemoMVC_2Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                //// Nova Rota
                //routes.MapRoute(
                //    name: "Modulos",
                //    template: "Gestao/{controller=Home}/{action=Index}/{id?}"); // Adicionando um módulo "Gestão" na frente da rota.

                //// Nova Rota
                //routes.MapRoute(
                //    name: "Categoria",
                //    template: "{controller=Home}/{action=Index}/{id}/{Categoria?}"); // Adicionando um novo parâmetro chamado "Categoria".
                //    // Caso o último item do pattern for ou não obrigatório, o penúltimo item deve ser obrigatório.

                // Rota padrão: sempre deve ser a última especificada e não deve ser alterada.
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
