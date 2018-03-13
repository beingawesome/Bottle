using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Metadata
{
    public interface IMetadata : IReadOnlyMetadata
    {
        void Set<TMetadata>(TMetadata metadata);
    }
}
