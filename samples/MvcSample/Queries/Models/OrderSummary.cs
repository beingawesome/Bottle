using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample.Queries.Models
{
    public class OrderSummary
    {
        public OrderSummary(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
