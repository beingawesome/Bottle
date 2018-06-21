using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Metadata
{
    internal class DynamicMetadata : Dictionary<string, JToken>, IMetadata
    {
        public IMetadata Clone()
        {
            var clone = new DynamicMetadata();

            foreach (var item in this)
            {
                clone.Add(item.Key, item.Value);
            }

            return clone;
        }

        public TMetadata Get<TMetadata>()
        {
            var key = typeof(TMetadata).Name;

            return TryGetValue(key, out var value)
                        ? value.ToObject<TMetadata>()
                        : default;
        }

        public TMetadata GetRequired<TMetadata>()
        {
            var key = typeof(TMetadata).Name;

            return TryGetValue(key, out var value)
                        ? value.ToObject<TMetadata>()
                        : throw new MetadataNotFound(typeof(TMetadata));
        }

        public void Set<TMetadata>(TMetadata feature)
        {
            var key = typeof(TMetadata).Name;

            this[key] = JToken.FromObject(feature);
        }
    }
}
