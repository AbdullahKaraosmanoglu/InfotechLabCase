using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public ServiceCategoryController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        /// <summary>
        /// Bütün Hizmet Alanlarını Getiren Api
        /// </summary>
        /// <returns>serviceList</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCategoryModel>>> GetServiceCategories()
        {
            if (dbContextInfotechLabCase.TblServiceCategory == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var serviceList = await dbContextInfotechLabCase.TblServiceCategory.ToListAsync();

            return Ok(new {Message=BaseClass.GetServicesSuccess,ResponseData=serviceList});
        }

        /// <summary>
        /// Yeni Hizmet Alanı Oluşturan Api
        /// </summary>
        /// <param name="serviceCategoryModel"></param>
        /// <returns>serviceCategoryModel</returns>

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

        /// <summary>
        /// Hizmet Alanı Güncelleyen Api
        /// </summary>
        /// <param name="serviceCategoryId"></param>
        /// <param name="serviceCategoryModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Kayıtlı hizmet ALanı Varmı Yokmu Diye Kontrol Eden BOOL Method
        /// </summary>
        /// <param name="serviceCategoryId"></param>
        /// <returns>true or false</returns>
        private bool ServiceAvailable(int serviceCategoryId)
        {
            return (dbContextInfotechLabCase.TblServiceCategory?.Any(x => x.ServiceCategoryId == serviceCategoryId)).GetValueOrDefault();
        }

        /// <summary>
        /// Belirli Hizmet Alnını Silen Api
        /// </summary>
        /// <param name="serviceCategoryId"></param>
        /// <returns></returns>
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
