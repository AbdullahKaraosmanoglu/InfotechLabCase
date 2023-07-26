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

        /// <summary>
        /// Yeni Bir Teklif Formu Oluşturan Api
        /// </summary>
        /// <param name="offerModel"></param>
        /// <returns>offerModel</returns>
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

        /// <summary>
        /// Müşteririnin Gönderdiği Teklif Formlarını Getirir
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>offers</returns>
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

        /// <summary>
        /// Ustaya Gönderilen Teklif Formlarını Getirir
        /// </summary>
        /// <param name="expertID"></param>
        /// <returns>offers</returns>
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

        /// <summary>
        /// Hizmetin Gönderildi, Görüldü ve Tamamlandı Belirtmesini Sağlayan Api
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="offerModel"></param>
        /// <returns></returns>
        [HttpPut("UpdateStatus/{offerId}")]
        public async Task<ActionResult> UpdateStatusByExpertId(int offerId, OfferModel offerModel)
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
                    return NotFound(new { Message = BaseClass.UpdateOfferStatusFailedByOfferId });
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { Message = BaseClass.UpdateOfferStatus });
        }

        /// <summary>
        /// İstenilen Teklifin Mevcut Olup Olmadığını Kontrol Eden BOOL Method
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        private bool OfferAvailable(int offerId)
        {
            return (dbContextInfotechLabCase.TblOffer?.Any(x => x.OfferId == offerId)).GetValueOrDefault();
        }

        /// <summary>
        /// Gönderilen Teklifin Güncellenmesini Sağlayan Api 
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="offerStatus"></param>
        /// <returns>offer</returns>
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
            return Ok(new { Message = BaseClass.UpdateOfferSuccess, ResponseData = offer });
        }

        /// <summary>
        /// Teklifin FDurumunu Aktiften Pasife Çeken Api
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>offer</returns>
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
            return Ok(new { Message = BaseClass.DeleteOfferSuccess, ResponseData = offer });
        }

        /// <summary>
        /// Ustanın İşi Tamamladığını Belirten Api
        /// </summary>
        /// <param name="expertID"></param>
        /// <returns>comletedWorkCount</returns>
        [HttpGet]
        [Route("ExpertCompletedWork/{expertID}")]
        public async Task<ActionResult<List<OfferModel>>> ExpertCompletedWork(int expertID)
        {
            var offers = await dbContextInfotechLabCase.TblOffer.Where(x => x.ExpertId == expertID && x.OfferStatus == BaseClass.OfferStatus.Completed.GetHashCode()).ToListAsync();
            var comletedWorkCount = offers.Count;
            if (offers.Count == 0)
            {
                return NotFound(new { Message = BaseClass.DataEntryNotFoundOfferWithExpertId });
            }
            return Ok(new { Message = BaseClass.ExpertCompletedWork, ResponseData = comletedWorkCount });
        }
    }
}
