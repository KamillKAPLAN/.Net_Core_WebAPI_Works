using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _01_ExampleAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* Static dosya için wwroot klasörü kullanýlýr.
             * Uygulama içinde olmadýðý için sýfýrdan kurmak gereklidir.
             * wwwroot klasörünü aktive etmek için Startup.cs dosyasýna Configure metodu içine aþaðýdaki kod satýrlarý eklenýr.
             * app.UseDefaultFiles();
             * app.UseStaticFiels();
             */
            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("<div style='text-align: center; color: chocolate; border: 1px solid red; padding: 1 %; '>KAMIL KAPLAN</div>");
                });
            });
        }
    }
}