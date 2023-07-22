using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;

        public LoginController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (dbContextInfotechLabCase.TblCustomer == null)
            {
                return NotFound();
            }
            var customerList = await dbContextInfotechLabCase.TblCustomer.ToListAsync();
            var customer = customerList.Where(
                x => x.CustomerEmail == email && x.CustomerPassword == password && x.IsActive == BaseClass.IsActive.Active.GetHashCode()).FirstOrDefault();
            if (customer != null)
            {
                return Ok(new { Message= BaseClass.LoginSuccessfuly,ResponseData= customer });
            }

            if (dbContextInfotechLabCase.TblExpert == null)
            {
                return NotFound();
            }

            var expertList = await dbContextInfotechLabCase.TblExpert.ToListAsync();
            var expert = expertList.Where(
                x => x.ExpertEmail == email && x.ExpertPassword == password&& x.IsActive==BaseClass.IsActive.Active.GetHashCode()).FirstOrDefault();

            if (expert != null)
            {
                return Ok(expert);
            }

            return Ok(new { Message = BaseClass.UserNotFound });


        }


    }
}
