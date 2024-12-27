using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductOrderManagementSystem.Models;
using ProductOrderManagementSystem.Repositeries;

namespace ProductOrderManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductOrderContext _context;

        public ProductController(ProductOrderContext context)
        {
            _context = context;
        }

        // HTTP GET: api/Product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // HTTP GET: api/Product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            return Ok(product);
        }

        // HTTP POST: api/Product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product.Id);
            }
            return BadRequest(ModelState);
        }

        // HTTP PUT: api/Product/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;

            _context.SaveChanges();
            return NoContent();
        }

        // HTTP DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
