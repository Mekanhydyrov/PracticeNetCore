using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using PracticeNetCore.Interfaces;
using PracticeNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IKategoryRepository, KategoriRepository>();
            services.AddScoped<IUrunRepository, UrunRepository>();
            services.AddScoped<IUrunKategoriRepository, UrunKategoriRepository>();
            services.AddControllersWithViews();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //Node Modules disari acma
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine
            //    (Directory.GetCurrentDirectory(), "node_modules")),
            //    RequestPath = "/content"
            //});

            app.UseStaticFiles();

            app.UseSession();

            //Webigem.com/Home/Index
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name:"default",pattern:
                    "{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}
