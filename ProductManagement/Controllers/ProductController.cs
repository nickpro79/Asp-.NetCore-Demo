using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository ProductRepository;

        public ProductController(IProductRepository productRepository) { 
        ProductRepository = productRepository;
        }
        
    [HttpGet]
    public IActionResult GetProducts()
        {
            IEnumerable<Product> products =ProductRepository.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductsById(Guid id)
        {
            var p = ProductRepository.GetProductById(id);
            if (p != null) { 
            return Ok(p);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]Product p)
        {
            var productAdded = ProductRepository.AddProduct(p);
            if (productAdded)
            {
                return Ok(p);
            }
            return Ok("Product not Added");
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateProduct([FromRoute]Guid Id,[FromBody]Product p) {
            var UpdatedProduct = ProductRepository.UpdateProduct(Id, p);
            if (UpdatedProduct != null) {
                return Ok(UpdatedProduct);
            }
            return NotFound();
        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteProduct([FromRoute] Guid Id) { 
        var p = ProductRepository.DeleteProduct(Id);
            if (p == true)
            {
                return Ok($"Product with id={Id} was deleted");
            }
            return Ok($"Product with id={Id} was not Found");
        }

        [HttpGet("find/{amount}")]

        public IActionResult SearchByAmount([FromRoute] double amount)
        {
            var p = ProductRepository.GetProductsGreaterThanAmount(amount);
            return Ok(p);
        }
    }

 

}
