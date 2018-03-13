using Bottle.Metadata;
using Bottle.Versioning;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bottle
{
    public interface ICommandHandler<T> where T : Command
    {
        Task<Commit> HandleAsync(T command, IReadOnlyMetadata metadata);
    }
}
