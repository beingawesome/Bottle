using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Metadata
{
    public interface IReadOnlyMetadata
    {
        TMetadata Get<TMetadata>();
    }
}
