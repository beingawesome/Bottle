using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle
{
    public class QueryResult<T> : ErrorContainer
    {
        public QueryResult() : this(default) { }

        public QueryResult(T value) : base() => Value = value;

        public T Value { get; }
    }
}
