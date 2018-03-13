using Bottle;
using Bottle.Metadata;
using MvcSample.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample.Queries
{
    public class GetAllOrders : Query<IEnumerable<OrderSummary>>
    {
    }

    namespace Handlers
    {
        internal class GetAllOrdersHandlers : IQueryHandler<GetAllOrders, IEnumerable<OrderSummary>>
        {
            public object CompletedTask { get; private set; }

            public async Task<IEnumerable<OrderSummary>> HandleAsync(GetAllOrders query, IReadOnlyMetadata metadata)
            {
                await Task.CompletedTask;

                return new[] { new OrderSummary("66") };
            }
        }
    }
}
