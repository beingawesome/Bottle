using Bottle.Configuration;
using Bottle.Internal;
using System;
using System.Threading.Tasks;

namespace Bottle
{
    public class MessageBus
    {
        private readonly IServiceProvider _services;
        private readonly MessageBusOptions _options;

        internal MessageBus(IServiceProvider services, MessageBusOptions options)
        {
            _services = services;
            _options = options;
        }

        public async Task<CommandResult> SendAsync(Command command)
        {
            var result = await new Pipeline(_services, _options.Commands).InvokeAsync(command).ConfigureAwait(false);

            return result?.AsCommandResult();
        }

        public async Task<QueryResult<T>> SendAsync<T>(Query<T> query)
        {
            var result = await new Pipeline(_services, _options.Queries).InvokeAsync(query).ConfigureAwait(false);

            return result?.AsQueryResult<T>();
        }
    }
}
