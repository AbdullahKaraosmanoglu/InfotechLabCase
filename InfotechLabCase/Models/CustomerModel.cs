using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustormerId { get; set; }
        [Required]
        public string? CustomerEmail { get; set; }
        [Required]
        public string? CustomerPassword { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? CustomerSurname { get; set; }
        [Required]
        public string? CustomerCity { get; set; }
        [Required]
        public string? CustomerDistrict { get; set; }
        [Required]
        public string? CustomerNeighbourhood { get; set; }
        [Required]
        public string? CustomerPhone { get; set; }
        public DateTime SystemDate { get; set; }
        public DateTime UpdateSystemDate { get; set; }
        public int IsActive { get; set; }
        public ICollection<OfferModel>? OfferModels { get; set; }
    }
}
