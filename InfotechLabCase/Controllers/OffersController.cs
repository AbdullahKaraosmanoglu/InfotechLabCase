using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public OffersController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<OfferModel>>> CreateOffer(OfferModel offerModel)
        {
            if (offerModel != null)
            {
                await dbContextInfotechLabCase.TblOffer.AddAsync(offerModel);
                await dbContextInfotechLabCase.SaveChangesAsync();
                return Ok(new { Message = BaseClass.SendingOffer, ResponseData = offerModel });
            }
            return BadRequest(new { Message = BaseClass.BadRequest });
        }

        [HttpGet]
        [Route("customer/{customerID:int}")]
        public async Task<ActionResult<List<OfferModel>>> GetOffersByCustomerId(int customerID)
        {
            var offers = await dbContextInfotechLabCase.TblOffer.Where(x => x.CustomerId == customerID).ToListAsync();
            if (offers.Count == 0)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithCustomerId });
            }
            return Ok(new { Message = BaseClass.GetOffersForCustomerId, ResponseData = customerID });
        }


        [HttpGet]
        [Route("expert/{expertID:int}")]
        public async Task<ActionResult<List<OfferModel>>> GetOffersByExpertId(int expertID)
        {
            var offers = await dbContextInfotechLabCase.TblOffer.Where(x => x.ExpertId == expertID).ToListAsync();
            if (offers.Count == 0)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithExpertId });
            }
            return Ok(new { Message = BaseClass.GetOffersForExpertId, ResponseData = expertID });
        }
    }
}
