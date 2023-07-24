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
                return Ok(new { Message = BaseClass.SendingOffer, ResponseData = offerModel });
            }
            return BadRequest(new {Message=BaseClass.BadRequest});
        }

        [HttpGet]
        [Route("{customerID:int}")]
        public async Task<ActionResult<List<OfferModel>>> GetOffersByCustomerId(int customerID)
        {
            var offer = await dbContextInfotechLabCase.TblOffer.Where(x => x.CustomerId == customerID).ToListAsync();
            if (offer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithCustomerId });
            }
            return Ok(new { Message = BaseClass.GetOffersForCustomerId, ResponseData = customerID });
        }
    }
}
