using Bottle.Configuration;
using Bottle.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bottle.InMemory
{
    public static class PipelineOptionsBuilderExtensions
    {
        public static PipelineOptionsBuilder UseInMemory(this PipelineOptionsBuilder builder)
        {
            builder.Use(() =>
            {
                return Middleware;

                Task<MessageResult> Middleware(MessageContext context, MessageDelegate next)
                    => Handle((dynamic)context.Message, context);
            }, true);
            
            return builder;
        }

        private static async Task<MessageResult> Handle(Command command, MessageContext context) => await CommandHandler.Handle((dynamic)command, context).ConfigureAwait(false);
        
        private static async Task<MessageResult> Handle<T>(Query<T> query, MessageContext context) => await QueryHandler<T>.Handle((dynamic)query, context).ConfigureAwait(false);

        private static class CommandHandler
        {
            public static async Task<MessageResult> Handle<T>(T command, MessageContext context) where T : Command
            {
                var handler = context.Services.GetRequiredService<ICommandHandler<T>>();

                var result = await handler.HandleAsync(command, context.Metadata).ConfigureAwait(false);

                return new CommitResult(result);
            }
        }

        private static class QueryHandler<TResult>
        {
            public static async Task<MessageResult> Handle<T>(T query, MessageContext context) where T : Query<TResult>
            {
                var handler = context.Services.GetRequiredService<IQueryHandler<T, TResult>>();

                var result = await handler.HandleAsync(query, context.Metadata).ConfigureAwait(false);

                return new ObjectResult(result);
            }
        }
    }
}