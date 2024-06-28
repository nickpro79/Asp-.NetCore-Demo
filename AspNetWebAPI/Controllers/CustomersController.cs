using AspNetWebAPI.Models;
using AspNetWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
              IEnumerable<Customer> c = _customerRepository.GetAllCustomers();
              return Ok(c);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomersByID([FromRoute]int id)
        {
            Customer c = _customerRepository.GetCustomerById(id);
            if (c == null) { 
            return NotFound();
            }
            return Ok(c);
        }

        [HttpPost]
        public IActionResult AddCustomers([FromBody]Customer c)
        {
            var isCustomerAdded = _customerRepository.AddCustomer(c);
            if (isCustomerAdded == true)
            {
                return Ok(c);
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomers([FromRoute]int id,[FromBody]Customer c)
        {
            var customer = _customerRepository.UpdateCustomer(id, c);
            if (customer == null)
            {
                return NotFound($"The Customer with id={id} is not found");
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomers([FromRoute]int id)
        {
            var customerDeleted = _customerRepository.DeleteCustomer(id);
            if (customerDeleted)
            {
                return Ok($"Customer with id = {id} is deleted");
            }
            return Ok($"Customer with id = {id} is not found");
        }
    }
}
