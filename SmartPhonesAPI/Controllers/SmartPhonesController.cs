using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPhonesAPI.Models;
using SmartPhonesAPI.Services;

namespace SmartPhonesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartPhonesController : ControllerBase
    {
        ISmartphoneRepository _smartPhoneRepository;
        public SmartPhonesController(ISmartphoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }

        [HttpGet]
        public IActionResult GetSmartphones() {
        IEnumerable<SmartPhone>  s= _smartPhoneRepository.GetAll();
        return Ok(s);
        }
        [HttpPost]
        public IActionResult AddSmartphone([FromBody] SmartPhone s)
        {
            var b = _smartPhoneRepository.Add(s);
            return Ok(s);   
        }
    }
}
