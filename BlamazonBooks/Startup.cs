using BlamazonBooks.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlamazonBooks
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; set; }
        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookstoreContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
           });
            services.AddScoped<IBlamazonBooksRepository, EFBlamazonBooksRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                // URL when the user enters a page number and a category  
                endpoints.MapControllerRoute(
                    name: "typepage",
                    pattern: "{Category}/Page{pageNum}",
                    defaults: new { controller = "home", action = "Index" });

                // URL when the user enters just a page number
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { controller = "Home", action = "Index", pageNum = 1 });

                // URL when the user enters just a category 
                endpoints.MapControllerRoute(
                    name: "type",
                    pattern: "{Category}",
                    defaults: new { controller = "home", action = "Index", pageNum = 1 });

                // URL when the user enters nothing 
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
