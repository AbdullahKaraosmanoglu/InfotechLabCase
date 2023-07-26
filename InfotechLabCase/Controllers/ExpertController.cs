using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public ExpertController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        /// <summary>
        /// Ustaları Getiren Api
        /// </summary>
        /// <returns>experList</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpertModel>>> GetExperts()
        {
            if (dbContextInfotechLabCase.TblExpert == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var experList = await dbContextInfotechLabCase.TblExpert.ToListAsync();
            return Ok(new { Message = BaseClass.GetExperts, ResponseData = experList });
        }

        /// <summary>
        /// Belirli ExpertId'ye Göre Usta Getiren Api
        /// </summary>
        /// <param name="expertId"></param>
        /// <returns>expert</returns>
        [HttpGet]
        [Route("{expertId:int}")]
        public async Task<ActionResult<ExpertModel>> GetExpertByExpertId(int expertId)
        {
            if (dbContextInfotechLabCase.TblExpert == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var expert = await dbContextInfotechLabCase.TblExpert.FindAsync(expertId);

            if (expert == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpertId });
            }
            return Ok(new { Message = BaseClass.ProfileFound, ResponseData = expert });
        }

        /// <summary>
        /// Yeni Bir Usta Profili Oluşturan Api
        /// </summary>
        /// <param name="expertModel"></param>
        /// <returns>expertModel</returns>
        [HttpPost]
        [Route("CreateExpert/")]
        public async Task<ActionResult<CustomerModel>> CreateExpert(ExpertModel expertModel)
        {

            dbContextInfotechLabCase.TblExpert.Add(expertModel);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.CreateExpertSuccess, ResponseData = expertModel });
        }
        /// <summary>
        /// Usta Profilini Güncelleyen Api
        /// </summary>
        /// <param name="expertId"></param>
        /// <param name="expertModel"></param>
        /// <returns></returns>
        [HttpPut("UpdateExpert/{expertId}")]
        public async Task<ActionResult> UpdateExpertByExpertId(int expertId, ExpertModel expertModel)
        {
            if (expertId != expertModel.ExpertId)
            {
                return BadRequest(new { Message = BaseClass.BadRequest });
            }
            dbContextInfotechLabCase.Entry(expertModel).State = EntityState.Modified;

            try
            {
                await dbContextInfotechLabCase.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpertAvailable(expertId))
                {
                    return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpertId });
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { Message = BaseClass.UpdateProfileSuccess });
        }
        /// <summary>
        /// Ustanın Mevcut Olup ve ya Aktif Olup Olmadığını Kontrol Eden Bool Tipinde Method
        /// </summary>
        /// <param name="expertId"></param>
        /// <returns></returns>
        private bool ExpertAvailable(int expertId)
        {
            return (dbContextInfotechLabCase.TblExpert?.Any(x => x.ExpertId == expertId)).GetValueOrDefault();
        }

        /// <summary>
        /// Ustanın Profilini Aktiften Pasife Çeken Api
        /// </summary>
        /// <param name="expertId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteExpert/{expertId}")]
        public async Task<IActionResult> DeleteExpertByExpertId(int expertId)
        {
            if (dbContextInfotechLabCase.TblExpert == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }

            var expert = await dbContextInfotechLabCase.TblExpert.FindAsync(expertId);

            if (expert == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpertId });
            }
            expert.IsActive = BaseClass.IsActive.Passive.GetHashCode();

            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.DeleteProfileSuccess });
        }

        /// <summary>
        /// Anasayfada Arama Çubuğunda Search Yapmayı Sağlayan Api
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="districtId"></param>
        /// <param name="serviceCategoryId"></param>
        /// <returns>expert</returns>
        [HttpPost]
        [Route("SearchExpert/")]
        public async Task<ActionResult> SearchExpert(int? cityId, int? districtId, int? serviceCategoryId)
        {
            if (cityId != null && districtId != null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                                x => x.CityId == cityId && x.DistrictId == districtId && x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            else if (cityId != null && districtId != null && serviceCategoryId == null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.CityId == cityId && x.DistrictId == districtId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            else if (cityId != null && districtId == null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.CityId == cityId && x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            else if (cityId == null && districtId != null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.DistrictId == districtId && x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            else if (cityId != null && districtId == null && serviceCategoryId == null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.CityId == cityId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            else if (cityId == null && districtId != null && serviceCategoryId == null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.DistrictId == districtId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            else if (cityId == null && districtId == null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = BaseClass.SearchExpert, ResponseData = expert });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }


    }
}
