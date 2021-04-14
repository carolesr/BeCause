using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
    }
}
