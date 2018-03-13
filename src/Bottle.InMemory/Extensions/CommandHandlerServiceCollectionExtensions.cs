using Bottle;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CommandHandlerServiceCollectionExtensions
    {

        private static readonly Type HandlerType = typeof(ICommandHandler<>);

        public static IServiceCollection AddCommandHandlersFromAssembly<T>(this IServiceCollection services) => services.AddCommandHandlersFromAssembly(typeof(T).Assembly);

        private static IServiceCollection AddCommandHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
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
