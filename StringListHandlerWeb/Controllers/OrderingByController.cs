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
        [HttpPost]
        public JsonResult Position([FromBody] ListToSort listToSort)
        {
            IList result = OrderingBy.Position(listToSort.Names, listToSort.Order);

            return new JsonResult(result);
        }

    }
}
