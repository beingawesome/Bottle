using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Configuration
{
    internal class MessageBusOptions
    {
        public PipelineOptions Commands { get; } = new PipelineOptions();
        public PipelineOptions Queries { get; } = new PipelineOptions();
    }
}
