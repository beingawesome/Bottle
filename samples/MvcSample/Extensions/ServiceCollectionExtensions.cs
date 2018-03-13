using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddCommandHandlersFromAssembly<Marker>();

            return services;
        }

        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.AddQueryHandlersFromAssembly<Marker>();

            return services;
        }

        private class Marker { }
    }
}
