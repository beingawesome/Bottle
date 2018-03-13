using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Internal
{
    public abstract class MessageResult
    {
        public virtual CommandResult AsCommandResult() => throw new NotSupportedException();
        public virtual QueryResult<T> AsQueryResult<T>() => throw new NotSupportedException();
    }
}
