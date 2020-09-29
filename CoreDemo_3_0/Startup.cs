using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo_3_0.Context;
using CoreDemo_3_0.Helper;
using CoreDemo_3_0.Interface;
using CoreDemo_3_0.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreDemo_3_0
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
            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("JobConnection")));

            //Job service  
            services.AddScoped<IJobService, JobService>();

            //Department service  
            services.AddScoped<IDepartmentService, DepartmentService>();

            //Job Vacancy service  
            services.AddScoped<IVacancyService, VacancyService>();

            //Employee service  
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Camera service  
            services.AddScoped<IImageStoreService, ImageStoreService>();

            //Job Scheduling service  
            services.AddScoped<IJobSchedulingService, JobSchedulingService>();

            //Register dapper in scope  
            services.AddScoped<IDapperHelper, DapperHelper>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=JobScheduling}/{action=Index}/{id?}");
            });
        }
    }
}
