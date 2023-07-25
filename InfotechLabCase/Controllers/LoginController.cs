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
        [Route("Register/")]
        public async Task<ActionResult> Register(UserModel userModel)
        {
            var user = await dbContextInfotechLabCase.TblUser.Where(
                x => x.Email == userModel.Email && x.IsActive == BaseClass.IsActive.Active.GetHashCode()).FirstOrDefaultAsync();
            if (user != null)
            {
                return Ok("kullanıcı var");
            }

            dbContextInfotechLabCase.Entry(userModel).State = EntityState.Added;
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = "kayıt edildi", ResponseData = userModel });



        }

        [HttpPost]
        [Route("Login/")]
        public async Task<ActionResult> Login(string email, string password)
        {
            var user = await dbContextInfotechLabCase.TblUser.Where(
                x => x.Email == email && x.IsActive == BaseClass.IsActive.Active.GetHashCode()).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("(YOK) Kayıt Olunuz");
            }

            var customer = dbContextInfotechLabCase.TblCustomer.Where(x => x.UserId == user.UserId);
            if (customer != null)
            {
                return Ok(customer);
            }

            var expert = dbContextInfotechLabCase.TblExpert.Where(x => x.UserId == user.UserId);
            if (expert != null)
            {
                return Ok(expert);
            }
            return Ok(new { ResponseData = user });
        }
    }
}
