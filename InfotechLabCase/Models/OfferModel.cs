using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace InfotechLabCase.Models
{
    public class OfferModel
    {
        [Key]
        public int OfferId { get; set; }

        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        [ForeignKey("ExpertModel")]
        public int ExpertId { get; set; }
        public int OfferStatus { get; set; }
        [Required]
        public string? OfferMessage { get; set; }
        public DateTime SystemDate { get; set; }
        public DateTime UpdateSystemDate { get; set; }
        public int IsActive { get; set; }

        public CustomerModel? CustomerModel { get; set; }
        public ExpertModel? ExpertModel { get; set; }

    }
}
