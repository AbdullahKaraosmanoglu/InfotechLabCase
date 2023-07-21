using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace InfotechLabCase.Models
{
    public class OfferModel
    {
        [Key]
        public int OfferId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ExpertId { get; set; }
        [Required]
        public int OfferStatus { get; set; }
        [Required]
        [MaxLength(350)]
        public string OfferMessage { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
        public int IsActive { get; set; }

    }
}
