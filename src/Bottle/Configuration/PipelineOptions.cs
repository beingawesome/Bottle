using Bottle.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Configuration
{
    internal class PipelineOptions
    {
        private List<MiddlewareFactory> _middleware = new List<MiddlewareFactory>();

        public IEnumerable<MiddlewareFactory> Steps => _middleware;

        public PipelineOptionsBuilder Builder => new PipelineOptionsBuilder(this);
        public bool IsFrozen { get; private set; } = false;

        public void Append(MiddlewareFactory middleware)
        {
            if (IsFrozen) throw new Exception();

            _middleware.Add(middleware);
        }

        public void Freeze() => IsFrozen = true;
    }
}
