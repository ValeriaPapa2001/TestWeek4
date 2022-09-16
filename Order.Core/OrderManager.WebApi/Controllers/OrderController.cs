using Microsoft.AspNetCore.Mvc;
using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;


namespace OrderManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL _logic;

        public OrderController(IOrderBL logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders()
        {
            var orders = _logic.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(201, Type = typeof(Order))]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Input order is null.");
            bool result = _logic.InsertOrder(order);
            if (!result)
                return StatusCode(500, "Cannot create an order");

            return CreatedAtAction(nameof(GetOrderByCode), new { code = order.OrderCode}, order);
        }

        [HttpGet("{OrderCode}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetOrderByCode(string code)
        {
            var order = _logic.GetOrderByCode(code);
            if (order == null)
                return NotFound("Order not found: " + code);
            return Ok(order);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400, Type = typeof(string))]
        [ProducesResponseType(500, Type = typeof(string))]
        [ProducesResponseType(201, Type = typeof(Order))]
        public IActionResult UpdateOrder(int id, Order order)
        {
            if (id <= 0 || order == null)
                return BadRequest("Invalid parameters");
            if (id != order.Id)
                return BadRequest("The Id doesn't match");

            bool result = _logic.UpdateOrder(order);
            if (!result)
                return StatusCode(500, "Unable to update order");
            return Ok(order);
        }


        [HttpDelete("{OrderCode}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteOrder(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest("Invalid parameters");
            bool result = _logic.DeleteOrderByCode(code);
            if (!result)
                return StatusCode(500, "Cannot delete book");
            return Ok();
        }

    }
}
