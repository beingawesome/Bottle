using Bottle.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Internal
{
    public class MessageContext
    {
        internal MessageContext(Message message, IServiceProvider services)
        {
            Message = message;
            Services = services;
        }

        public Message Message { get; } 
        public IMetadata Metadata { get; } = new DynamicMetadata();
        public IServiceProvider Services { get; }
    }
}
