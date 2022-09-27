using Microsoft.AspNetCore.Mvc;
using StringListHandlerWeb.Models;
using StringListHandler;
using System.Collections;

namespace StringListHandlerWeb.Controllers
{
    [Route("api/OrderingBy")]
    [ApiController]
    public class OrderingByController : ControllerBase
    {
        public OrderingByController()
        {
            orderingBy = new OrderingBy();
        }

        [HttpPost]
        public JsonResult Position([FromBody] ListToSort listToSort)
        {
            IList result = orderingBy.Position(listToSort.Names, listToSort.Order);

            return new JsonResult(result);
        }

        private readonly IOrderingBy orderingBy;

    }
}
