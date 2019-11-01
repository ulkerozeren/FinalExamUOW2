using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExamUOW2.Web
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
            services.AddDbContext<DataContext1>(optionsAction => optionsAction.UseSqlServer(Configuration["ConnectionStrings:ConnectionString1"]));
            services.AddDbContext<DataContext2>(optionsAction => optionsAction.UseSqlServer(Configuration["ConnectionStrings:ConnectionString2"]));
            services.AddDbContext<DataContext3>(optionsAction => optionsAction.UseSqlServer(Configuration["ConnectionStrings:ConnectionString3"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IDataContext, DataContext1>();
            //services.AddScoped<IDataContext, DataContext2>();
            //services.AddScoped<IDataContext, DataContext3>();
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
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
