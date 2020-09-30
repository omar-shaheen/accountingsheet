using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ACCOUNTINGSHEET.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Mvc;
using ACCOUNTINGSHEET.Helper;
using AutoMapper;
using Microsoft.AspNetCore.SpaServices.AngularCli;
namespace ACCOUNTINGSHEET
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
            
          // services.AddRazorPages();
           services.AddDbContext<DB_A66DAB_accountingsheetContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("sqlconserver")), ServiceLifetime.Scoped);
           services.Configure<Audience>(Configuration.GetSection("Audience"));
           services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddControllers();
              services.AddMvc(options=>
              {
                  options.EnableEndpointRouting = false;
              });
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseSpaStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
             app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                
                if (env.IsDevelopment())
                {
                    //spa.Options.StartupTimeout = new TimeSpan.FromSeconds(120);
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                   // spa.UseProxyToSpaDevelopmentServer("http://ahmedderbala1991-001-site1.ctempurl.com/dist/");
                }
               
            });
            // app.UseCors(builder =>builder.AllowAnyOrigin());
            app.UseAuthorization();
        }
    }
}
