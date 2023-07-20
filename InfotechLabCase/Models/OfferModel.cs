using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace InfotechLabCase.Models
{
    public class OfferModel
    {
        [Key]
        public int OfferId { get; set; }
        public int CustomerId { get; set; }
        public int ExpertId { get; set; }
        public int ServiceCategoryId { get; set; }
        public int OfferStatus { get; set; }
        public string OfferMessage { get; set; }
        public DateTime OfferTranDate { get; set; }
    }
}
