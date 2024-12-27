using Microsoft.AspNetCore.Mvc;
using ProductOrderManagementSystem.Models;

namespace ProductOrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProductOrderContext _context;

        public OrderController(ProductOrderContext context)
        {
            _context = context;
        }

        // GET: api/order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);            
        }

        // GET: api/order/total
        [HttpGet("total")]
        public IActionResult GetTotalOrderAmount()
        {
            var totalAmount = _context.Orders.Sum(o => o.Quantity * o.Product.Price);
            return Ok(new { TotalAmount = totalAmount });
        }
    }
}
