using Bottle.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.InMemory
{
    internal class ObjectResult : MessageResult
    {
        public ObjectResult(object value) => Value = value;

        public object Value { get; }
        
        public override QueryResult<T> AsQueryResult<T>()
        {
            return new QueryResult<T>((T)Value);
        }
    }
}
