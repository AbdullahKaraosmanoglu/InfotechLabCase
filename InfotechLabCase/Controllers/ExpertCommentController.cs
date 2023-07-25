using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertCommentController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public ExpertCommentController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }
        //[HttpGet("city/{cityId}/district/{districtId}")]
        [HttpPost]
        [Route("CreateExpertComment/")]
        public async Task<ActionResult<List<ExpertCommentModel>>> CreateExpertComment(ExpertCommentModel expertCommentModel)
        {
            if (expertCommentModel != null)
            {
                await dbContextInfotechLabCase.TblExpertComment.AddAsync(expertCommentModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.SendingOffer, ResponseData = expertCommentModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }
        [HttpGet]
        [Route("GetExpertComment/{expertId:int}")]
        public async Task<ActionResult<ExpertCommentModel>> GetExpertCommentByExpertId(int expertId)
        {

            if (dbContextInfotechLabCase.TblExpertComment == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var commentList = await dbContextInfotechLabCase.TblExpertComment.Where(x=>x.ExpertId==expertId).ToListAsync();


            if (commentList == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpertId });
            }
            return Ok(new { Message = BaseClass.ProfileFound, ResponseData = commentList });
        }

        [HttpGet]
        [Route("GetCustomerComment/{customerId:int}")]
        public async Task<ActionResult<ExpertCommentModel>> GetCustomerCommentByCustomerId(int customerId)
        {

            if (dbContextInfotechLabCase.TblExpertComment == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpert });
            }
            var commentList = await dbContextInfotechLabCase.TblExpertComment.Where(x => x.CustomerId == customerId).ToListAsync();


            if (commentList == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundForExpertId });
            }
            return Ok(new { Message = BaseClass.ProfileFound, ResponseData = commentList });
        }
    }
}
