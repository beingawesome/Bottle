using Bottle;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class QueryHandlerServiceCollectionExtensions
    {
        private static readonly Type HandlerType = typeof(IQueryHandler<,>);

        public static IServiceCollection AddQueryHandlersFromAssembly<T>(this IServiceCollection services) => services.AddQueryHandlersFromAssembly(typeof(T).Assembly);

        private static IServiceCollection AddQueryHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            foreach (var mapping in GetHandlerMappings(assembly))
            {
                services.TryAddTransient(mapping.Key, mapping.Value);
            }

            return services;
        }

        private static IDictionary<Type, Type> GetHandlerMappings(Assembly asm)
        {
            return (from type in asm.DefinedTypes
                    where !type.IsAbstract && !type.IsInterface
                    from i in type.ImplementedInterfaces
                    let detail = i.GetTypeInfo()
                    where detail.IsGenericType
                    let def = detail.GetGenericTypeDefinition()
                    where def == HandlerType
                    select new { i, Impl = type.AsType() }).ToDictionary(x => x.i, x => x.Impl);
        }
    }
}
