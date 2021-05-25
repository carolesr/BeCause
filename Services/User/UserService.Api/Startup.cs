using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using System.Linq;
using Foundation.Api;
using Microsoft.EntityFrameworkCore;
using UserService.Repository.CommandDB;
using UserService.Repository;
using UserService.Repository.Repositories;

namespace UserService.Api
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

            #region DB contexts

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, UserRepository>();

            //services.AddDatabaseDeveloperPageExceptionFilter();

            #endregion

            #region Set up frameworks assemblies in Foudation

            var executingAssembly = Assembly.GetExecutingAssembly();
            services.SetUpSwaggerAssemblies(executingAssembly);
            var assemblyCore = AppDomain.CurrentDomain.Load("UserService.Core");
            services.SetUpMediatorAssemblies(assemblyCore);
            services.SetUpAutoMapperAssemblies(assemblyCore);
            services.SetUpFluentValidationAssemblies(assemblyCore);

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            #endregion
        }
    }
}
