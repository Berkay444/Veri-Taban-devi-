using System;
using Microsoft.AspNetCore.Mvc;
using ProductOrderManagementSystem.Models;

namespace ProductOrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ProductOrderContext _context;

        public CustomerController(ProductOrderContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null || string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Email))
            {
                return BadRequest("Müşteri adı ve e-posta adresi gereklidir.");
            }

            try
            {
                // Yeni müşteri ekle
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return Ok("Müşteri Başarıyla Eklendi!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
