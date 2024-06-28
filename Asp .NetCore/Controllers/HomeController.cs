using Microsoft.AspNetCore.Mvc;
using Asp_.NetCore.Models;
namespace Asp_.NetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customer = new Customer() { Id = 1 ,Name="John"};
            ViewBag.Title = "Welcome to UST";
            
            return View(customer);
        }


    }
}
