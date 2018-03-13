using Bottle;
using Bottle.Configuration;
using Bottle.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MessageBusServiceCollectionExtensions
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services, Action<PipelineOptionsBuilder, PipelineOptionsBuilder> configure)
        {
            var options = new MessageBusOptions();

            configure?.Invoke(options.Commands.Builder, options.Queries.Builder);

            services.TryAddTransient(s => new MessageBus(s, options));

            return services;
        }
    }
}
