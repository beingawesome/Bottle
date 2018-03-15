using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Metadata
{
    public class MetadataNotFound : Exception
    {
        public MetadataNotFound(Type type) : base($"Metadata of type [{type.AssemblyQualifiedName}] not found.") { }
    }
}
