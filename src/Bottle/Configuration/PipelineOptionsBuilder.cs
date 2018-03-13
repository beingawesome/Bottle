using Bottle.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Configuration
{
    public class PipelineOptionsBuilder
    {
        private readonly PipelineOptions _options;

        internal PipelineOptionsBuilder(PipelineOptions options) => _options = options;
        
        public PipelineOptionsBuilder Use(MiddlewareFactory factory) => Use(factory, false);
        
        public PipelineOptionsBuilder Use(MiddlewareFactory factory, bool freeze)
        {
            _options.Append(factory);

            if (freeze) _options.Freeze();

            return this;
        }
    }
}
