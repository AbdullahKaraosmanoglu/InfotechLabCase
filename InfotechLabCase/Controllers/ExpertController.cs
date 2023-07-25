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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpertModel>>> GetExperts()
        {
            if (dbContextInfotechLabCase.TblExpert == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var experList= await dbContextInfotechLabCase.TblExpert.ToListAsync();
            return Ok(new {Message="İşlem başarılı",ResponseData=experList});
        }

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

        [HttpPost]
        [Route("CreateExpert/")]

        public async Task<ActionResult<CustomerModel>> CreateExpert(ExpertModel expertModel)
        {

            dbContextInfotechLabCase.TblExpert.Add(expertModel);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok(new { Message = BaseClass.CreateExpertSuccess, ResponseData = expertModel });
        }

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

        private bool ExpertAvailable(int expertId)
        {
            return (dbContextInfotechLabCase.TblExpert?.Any(x => x.ExpertId == expertId)).GetValueOrDefault();
        }

        [HttpDelete("UpdateExpert/{expertId}")]
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

        
        [HttpPost]
        [Route("SearchExpert/")]
        public async Task<ActionResult> SearchExpert(int? cityId, int? districtId, int? serviceCategoryId)
        {
            if (cityId != null && districtId != null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                                x => x.CityId == cityId && x.DistrictId == districtId && x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            else if (cityId != null && districtId != null && serviceCategoryId == null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.CityId == cityId && x.DistrictId == districtId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            else if (cityId != null && districtId == null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.CityId == cityId && x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            else if (cityId == null && districtId != null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.DistrictId == districtId && x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            else if (cityId != null && districtId == null && serviceCategoryId == null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.CityId == cityId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            else if (cityId == null && districtId != null && serviceCategoryId == null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.DistrictId == districtId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            else if (cityId == null && districtId == null && serviceCategoryId != null)
            {
                var expert = await dbContextInfotechLabCase.TblExpert.Where(
                    x => x.ServiceCategoryId == serviceCategoryId).ToListAsync();
                return Ok(new { Message = "İşlem Başarılı", ResponseData = expert });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }


    }
}
