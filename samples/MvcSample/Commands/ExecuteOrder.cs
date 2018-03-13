using Bottle;
using Bottle.Metadata;
using Bottle.Versioning;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample.Commands
{
    public class ExecuteOrder : Command
    {
        public ExecuteOrder(string id)
        {
            Id = id;
        }

        [Required(ErrorMessage = "Order ID is required")]
        public string Id { get; }
    }

    namespace Handlers
    {
        internal class ExecuteOrderHandler : ICommandHandler<ExecuteOrder>
        {
            private readonly ILogger<ExecuteOrderHandler> _logger;

            public ExecuteOrderHandler(ILogger<ExecuteOrderHandler> logger) => _logger = logger;

            public Task<Commit> HandleAsync(ExecuteOrder command, IReadOnlyMetadata metadata)
            {
                var json = JsonConvert.SerializeObject(command, Formatting.Indented);

                _logger.LogInformation(json);

                return Task.FromResult(Commit.Any);
            }
        }
    }
}
