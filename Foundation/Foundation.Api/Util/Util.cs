using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;

namespace Foundation.Api
{
    public static class Util
    {
        public static void SetUpMediatorAssemblies(this IServiceCollection services, Assembly assembly)
        {
            if (assembly == null)
                throw new NullReferenceException();

            services.AddMediatR(assembly);
        }

        public static void SetUpAutoMapperAssemblies(this IServiceCollection services, Assembly assembly)
        {
            if (assembly == null)
                throw new NullReferenceException();

            services.AddAutoMapper(assembly);
        }

        public static void SetUpSwaggerAssemblies(this IServiceCollection services, Assembly assembly)
        {
            if (assembly == null)
                throw new NullReferenceException();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BeCause API",
                    Description = "A simple example ASP.NET Core Web API"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void SetUpFluentValidationAssemblies(this IServiceCollection services, Assembly assembly)
        {
            if (assembly == null)
                throw new NullReferenceException();

            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly));
        }
    }
}
