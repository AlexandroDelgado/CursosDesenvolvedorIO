using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC_5.Data;

namespace MinhaDemoMVC_5
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
            services.AddControllersWithViews();

            services.AddDbContext<MinhaDemoMVC_5Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MinhaDemoMVC_5Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //// Nova Rota
                //endpoints.MapControllerRoute(
                //    name: "Modulos",
                //    pattern: "Gestao/{controller=Home}/{action=Index}/{id?}"); // Adicionando um m�dulo "Gest�o" na frente da rota.

                //// Nova Rota
                //endpoints.MapControllerRoute(
                //    name: "Categoria",
                //    pattern: "Gestao/{controller=Home}/{action=Index}/{id}/{Categoria?}"); // Adicionando um novo par�metro chamado "Categoria".
                //    // Caso o �ltimo item do pattern for ou n�o obrigat�rio, o pen�ltimo item deve ser obrigat�rio.

                // A rota padr�o sempre deve ser a �ltima especificada
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
