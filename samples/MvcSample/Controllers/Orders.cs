using Bottle;
using Microsoft.AspNetCore.Mvc;
using MvcSample.Commands;
using MvcSample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample.Controllers
{
    [Route("api/[controller]")]
    public class Orders : Controller
    {
        private readonly MessageBus _bus;

        public Orders(MessageBus bus) => _bus = bus;

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllOrders();

                var result = await _bus.SendAsync(query);

                if (result.IsSuccess) return Json(result.Value);

                ModelState.Merge(result);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "An unexpected error occurred.");
            }

            return BadRequest(ModelState);
        }
    }
}
