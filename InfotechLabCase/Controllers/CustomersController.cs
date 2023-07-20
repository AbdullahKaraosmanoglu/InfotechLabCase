using Microsoft.AspNetCore.Mvc;

namespace InfotechLabCase.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
