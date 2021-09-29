using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SBA_BACKEND.Domain.Persistence.Contexts;
using SBA_BACKEND.Domain.Persistence.Repositories;
using SBA_BACKEND.Domain.Services;
using SBA_BACKEND.Persistence.Repositories;
using SBA_BACKEND.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND
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

            services.AddControllers();

            //CORS
            services.AddCors();

            // Database Connection Configuration

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("HerokuConnectionMySQL"));
                //options.UseMySQL(Configuration.GetConnectionString("SmarterAspMySQLConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IOpinionRepository, OpinionRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<ISpecialityTechnicianRepository, SpecialityTechnicianRepository>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IOpinionService, OpinionService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ISpecialityService, SpecialityService>();
            //services.AddScoped<ISpecialityTechnicianService, SpecialityTechnicianService>();
            services.AddScoped<ITechnicianService, TechnicianService>();
            services.AddScoped<IUserService, UserService>();

            // Apply Endpoints Naming Convention
            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper Setup
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SBA_BACKEND", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SBA_BACKEND v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS Configuration
            app.UseCors(options => options
                .SetIsOriginAllowed(x => _ = true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
