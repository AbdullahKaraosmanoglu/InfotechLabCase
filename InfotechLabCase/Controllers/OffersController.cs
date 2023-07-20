using Microsoft.AspNetCore.Mvc;

namespace InfotechLabCase.Controllers
{
    public class OffersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
