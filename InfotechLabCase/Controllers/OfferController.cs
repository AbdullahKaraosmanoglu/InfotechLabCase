using InfotechLabCase.Data;
using InfotechLabCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly DbContextInfotechLabCase dbContextInfotechLabCase;
        public OfferController(DbContextInfotechLabCase context)
        {
            this.dbContextInfotechLabCase = context;
        }

        [HttpPost]
        [Route("CreateOffer/")]
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
        [Route("customer/{customerID}")]
        public async Task<ActionResult<List<OfferModel>>> GetOffersByCustomerId(int customerID)
        {
            var offers = await dbContextInfotechLabCase.TblOffer.Where(x => x.CustomerId == customerID).ToListAsync();
            if (offers.Count == 0)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithCustomerId });
            }
            return Ok(new { Message = BaseClass.GetOffersForCustomerId, ResponseData = offers });
        }

        [HttpGet]
        [Route("expert/{expertID}")]
        public async Task<ActionResult<List<OfferModel>>> GetOffersByExpertId(int expertID)
        {
            var offers = await dbContextInfotechLabCase.TblOffer.Where(x => x.ExpertId == expertID).ToListAsync();
            if (offers.Count == 0)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithExpertId });
            }
            return Ok(new { Message = BaseClass.GetOffersForExpertId, ResponseData = offers });
        }

        [HttpPut("UpdateStatus/{offerId}")]
        public async Task<ActionResult> UpdateExpertByExpertId(int offerId, OfferModel offerModel)
        {
            if (offerId != offerModel.OfferId)
            {
                return BadRequest(new { Message = BaseClass.BadRequest });
            }
            dbContextInfotechLabCase.Entry(offerModel).State = EntityState.Modified;

            try
            {
                await dbContextInfotechLabCase.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferAvailable(offerId))
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

        private bool OfferAvailable(int offerId)
        {
            return (dbContextInfotechLabCase.TblOffer?.Any(x => x.OfferId == offerId)).GetValueOrDefault();
        }

        [HttpPut]
        [Route("UpdateOfferStatus/")]
        public async Task<ActionResult<OfferModel>> UpdateOfferStatus(int offerId, int offerStatus)
        {
            var offer = await dbContextInfotechLabCase.TblOffer.Where(
                x => x.OfferId == offerId).FirstOrDefaultAsync();
            if (offer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithExpertId });
            }
            offer.OfferStatus = offerStatus;
            dbContextInfotechLabCase.Entry(offer).State = EntityState.Modified;
            await dbContextInfotechLabCase.SaveChangesAsync();
            return Ok(offer);
        }

        [HttpDelete]
        public async Task<ActionResult<OfferModel>> DeleteOffer(int offerId)
        {
            var offer = await dbContextInfotechLabCase.TblOffer.Where(
                x => x.OfferId == offerId).FirstOrDefaultAsync();
            if (offer == null)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithExpertId });
            }
            dbContextInfotechLabCase.Entry(offer).State = EntityState.Modified;
            offer.IsActive = BaseClass.IsActive.Passive.GetHashCode();
            await dbContextInfotechLabCase.SaveChangesAsync();
            return Ok(offer);
        }

        [HttpGet]
        [Route("ExpertCompletedWork/{expertID}")]
        public async Task<ActionResult<List<OfferModel>>> ExpertCompletedWork(int expertID)
        {
            var offers = await dbContextInfotechLabCase.TblOffer.Where(x => x.ExpertId == expertID&&x.OfferStatus==BaseClass.OfferStatus.Completed.GetHashCode()).ToListAsync();
            var comletedWorkCount = offers.Count;
            if (offers.Count == 0)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithExpertId });
            }
            return Ok(new { Message = BaseClass.GetOffersForExpertId, ResponseData = comletedWorkCount });
        }
    }
}
