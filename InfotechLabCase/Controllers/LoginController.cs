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

        /// <summary>
        /// Yeni Bir Kullanıcının Kayıt Olmasını Sağlayan Api
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns>userModel</returns>
        [HttpPost]
        [Route("Register/")]
        public async Task<ActionResult> Register(UserModel userModel)
        {
            var user = await dbContextInfotechLabCase.TblUser.Where(
                x => x.Email == userModel.Email && x.IsActive == BaseClass.IsActive.Active.GetHashCode()).FirstOrDefaultAsync();
            if (user != null)
            {
                return Ok(new { Message = BaseClass.RegisterFailed });
            }

            dbContextInfotechLabCase.Entry(userModel).State = EntityState.Added;
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.RegisterSuccess, ResponseData = userModel });
        }

        /// <summary>
        /// Kayıtlı Bir Kullanıcının Giriş Yapmasını Sağlayan Api
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>customer</returns>
        [HttpPost]
        [Route("Login/")]
        public async Task<ActionResult> Login(string email, string password)
        {
            var user = await dbContextInfotechLabCase.TblUser.Where(
                x => x.Email == email && x.IsActive == BaseClass.IsActive.Active.GetHashCode()).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new {Message=BaseClass.LoginFailed});
            }

            var customer =await dbContextInfotechLabCase.TblCustomer.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            if (customer != null)
            {
                return Ok(new { Message = BaseClass.LoginSuccess, ResponseData = customer });
            }

            var expert = await dbContextInfotechLabCase.TblExpert.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            if (expert != null)
            {
                return Ok(new { Message = BaseClass.LoginSuccess, ResponseData = expert });
            }
            return Ok(new {Message=BaseClass.RegisterSuccess, ResponseData = user });
        }
    }
}
