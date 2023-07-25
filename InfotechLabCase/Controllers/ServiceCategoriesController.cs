using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoriesController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public ServiceCategoriesController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        //public bool CanCreateServiceArea(AdminModel user)
        //{
        //    // "usta" ve "admin" rollerinin Id'lerini varsayılan olarak 1 ve 2 olarak kabul edelim.
        //    int ustaRoleId = 1;
        //    int adminRoleId = 3;

        //    // Kullanıcının rolleri içinde "usta" veya "admin" rolüne sahip olanları seçelim:
        //    var authorizedRoles = user.Roles.Where(x => x.RoleId == ustaRoleId || x.RoleId == adminRoleId);

        //    //var AuthorizedRoles = user.Roles.Where(role => role.Id == ustaRoleId || role.Id == adminRoleId);

        //    // Eğer kullanıcının "usta" veya "admin" rolü varsa hizmet alanını oluşturabilir.
        //    // Diğer durumlarda oluşturamaz.
        //    return authorizedRoles.Any();
        //}

        [HttpPost]
        public async Task<ActionResult<List<ServiceCategoryModel>>> CreateService(ServiceCategoryModel serviceCategoryModel)
        {

            if (serviceCategoryModel != null /*&& CanCreateServiceArea()*/)
            {
                await dbContextInfotechLabCase.TblServiceCategory.AddAsync(serviceCategoryModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = "hizmet alanı eklendi", ResponseData = serviceCategoryModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest, });
        }

        [HttpPut("{serviceCategoryId}")]
        public async Task<ActionResult> UpdateServiceByExpertId(int serviceCategoryId, ServiceCategoryModel serviceCategoryModel)
        {
            if (serviceCategoryId != serviceCategoryModel.ServiceCategoryId)
            {
                return BadRequest(new { Message = BaseClass.BadRequest });
            }

            dbContextInfotechLabCase.Entry(serviceCategoryModel).State = EntityState.Modified;
            try
            {
                await dbContextInfotechLabCase.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAvailable(serviceCategoryId))
                {
                    return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpertId });
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { Message = "servis alanı güncellendi" });
        }
        private bool ServiceAvailable(int serviceCategoryId)
        {
            return (dbContextInfotechLabCase.TblServiceCategory?.Any(x => x.ServiceCategoryId == serviceCategoryId)).GetValueOrDefault();
        }

        [HttpDelete("{serviceCategoryId}")]
        public async Task<IActionResult> DeleteServiceCategoryByServiceCategoryId(int serviceCategoryId)
        {
            if (dbContextInfotechLabCase.TblServiceCategory==null)
            {
                return NotFound(new { Message = "Kayıt Bulunamadı"});
            }

            var serviceCategory = await dbContextInfotechLabCase.TblServiceCategory.FindAsync(serviceCategoryId);

            if (serviceCategory==null)
            {
                return NotFound(new { Message = "Kayıt Bulunamadı" });
            }

            dbContextInfotechLabCase.Remove(serviceCategory);

            await dbContextInfotechLabCase.SaveChangesAsync();
            return Ok("Kayıt silindi");
        }
    }
}
