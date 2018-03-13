using Bottle.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bottle.Internal
{
    internal class Pipeline
    {
        private readonly IServiceProvider _services;
        private readonly PipelineOptions _options;

        public Pipeline(IServiceProvider services, PipelineOptions options)
        {
            _services = services;
            _options = options;
        }

        public async Task<MessageResult> InvokeAsync(Message message)
        {
            var context = new MessageContext(message, _services);

            var steps = _options.Steps.ToArray();
            var length = steps.Length;
            var i = 0;
            
            return await GetNext(context);
            
            Task<MessageResult> GetNext(MessageContext _) =>
                        i < length
                            ? steps[i++]().Invoke(_, GetNext) ?? throw new MessageResultNullException()
                            : throw new MessageNotHandledException();
        }
    }
}
