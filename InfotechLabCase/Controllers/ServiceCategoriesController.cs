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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCategoryModel>>> ServiceCategories()
        {
            if (dbContextInfotechLabCase.TblServiceCategory == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }

            return await dbContextInfotechLabCase.TblServiceCategory.ToListAsync();
        }

        [HttpPost]
        [Route("CreateService/")]
        public async Task<ActionResult<List<ServiceCategoryModel>>> CreateService(ServiceCategoryModel serviceCategoryModel)
        {

            if (serviceCategoryModel != null)
            {
                await dbContextInfotechLabCase.TblServiceCategory.AddAsync(serviceCategoryModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.CreateServiceSuccess, ResponseData = serviceCategoryModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest, });
        }

        [HttpPut("UpdateServiceCategory/{serviceCategoryId}")]
        public async Task<ActionResult> UpdateServiceByServiceCategoryId(int serviceCategoryId, ServiceCategoryModel serviceCategoryModel)
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
                    return NotFound(new { Message = BaseClass.DataEntryNotFoundServiceForServiceCategoryId });
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { Message = BaseClass.UpdateServiceSuccess });
        }
        private bool ServiceAvailable(int serviceCategoryId)
        {
            return (dbContextInfotechLabCase.TblServiceCategory?.Any(x => x.ServiceCategoryId == serviceCategoryId)).GetValueOrDefault();
        }

        [HttpDelete("DeleteServiceCategory/{serviceCategoryId}")]
        public async Task<IActionResult> DeleteServiceCategoryByServiceCategoryId(int serviceCategoryId)
        {
            if (dbContextInfotechLabCase.TblServiceCategory == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundServiceForServiceCategoryId });
            }

            var serviceCategory = await dbContextInfotechLabCase.TblServiceCategory.FindAsync(serviceCategoryId);

            if (serviceCategory == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundServiceForServiceCategoryId });
            }

            dbContextInfotechLabCase.Remove(serviceCategory);

            await dbContextInfotechLabCase.SaveChangesAsync();
            return Ok(new {Message=BaseClass.DeleteServiceSuccess});
        }
    }
}
