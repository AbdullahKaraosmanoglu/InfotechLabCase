using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public AdminController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }
        
    }
}
