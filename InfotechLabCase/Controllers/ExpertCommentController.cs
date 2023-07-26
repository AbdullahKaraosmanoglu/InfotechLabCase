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

        /// <summary>
        /// Ustaya Yorum Eklemeyi Sağlayan Api
        /// </summary>
        /// <param name="expertCommentModel"></param>
        /// <returns>expertCommentModel</returns>
        [HttpPost]
        [Route("CreateExpertComment/")]
        public async Task<ActionResult<List<ExpertCommentModel>>> CreateExpertComment(ExpertCommentModel expertCommentModel)
        {
            if (expertCommentModel != null)
            {
                await dbContextInfotechLabCase.TblExpertComment.AddAsync(expertCommentModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.CreateCommentForExpert, ResponseData = expertCommentModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }

        /// <summary>
        /// Ustanın Kendisine Yapılan Yorumları Görmesini Sağlayan Api
        /// </summary>
        /// <param name="expertId"></param>
        /// <returns>commentList</returns>
        [HttpGet]
        [Route("GetExpertComment/{expertId:int}")]
        public async Task<ActionResult<List<ExpertCommentModel>>> GetExpertCommentByExpertId(int expertId)
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
            return Ok(new { Message = BaseClass.GetExpertComment, ResponseData = commentList });
        }

        /// <summary>
        /// Müşterinin Ustalara Yaptığı Yorumları Getitmesini Sağlayan Api
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>commentList</returns>
        [HttpGet]
        [Route("GetExpertCommentForCustomers/{customerId:int}")]
        public async Task<ActionResult<List<ExpertCommentModel>>> GetExpertCommentByCustomerId(int customerId)
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
            return Ok(new { Message = BaseClass.GetExpertComment, ResponseData = commentList });
        }
    }
}
