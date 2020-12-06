using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExampleAPI
{
    public class Startup
    {
        /* �htiya� duydu�umuz service'lerimizi ekleriz. */
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /* HTTP request pipeline 'lar�m�z� y�netiriz. */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* Static dosya i�in wwroot klas�r� kullan�l�r.
             * Uygulama i�inde olmad��� i�in s�f�rdan kurmak gereklidir.
             * wwwroot klas�r�n� aktive etmek i�in Startup.cs dosyas�na Configure metodu i�ine a�a��daki kod sat�rlar� eklen�r.
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
                    await context.Response.WriteAsync("<div style='text-align: center; color: chocolate; border: 1px solid red; padding: 1 %; '>" +
                                                         "KAMIL KAPLAN" +
                                                      "</div>");
                });
            });
        }
    }
}