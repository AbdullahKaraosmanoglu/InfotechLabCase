using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertsController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public ExpertsController(DbContextInfotechLabCase context)
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

            return await dbContextInfotechLabCase.TblExpert.ToListAsync();
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
        public async Task<ActionResult<CustomerModel>> CreateExpert(ExpertModel expertModel)
        {

            dbContextInfotechLabCase.TblExpert.Add(expertModel);
            await dbContextInfotechLabCase.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{expertId}")]
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

        [HttpDelete("{expertId}")]
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
    }
}
