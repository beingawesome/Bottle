using Bottle.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bottle
{
    public interface IQueryHandler<T, TResult> where T : Query<TResult>
    {
        Task<TResult> HandleAsync(T query, IReadOnlyMetadata metadata);
    }
}
