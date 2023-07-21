using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfotechLabCase.Models
{
    public class ExpertModel
    {
        [Key]
        public int ExpertId { get; set; }

        [ForeignKey("ServiceCategoryModel")]
        public int ServiceCategoryId { get; set; }
        [Required]
        public string? ExpertEmail { get; set; }
        [Required]
        public string? ExpertPassword { get; set; }
        [Required]
        public string? ExpertName { get; set; }
        [Required]
        public string? ExpertSurname { get; set; }
        [Required]
        public string? ExpertCity { get; set; }
        [Required]
        public string? ExpertDistrict { get; set; }
        [Required]
        public string? ExpertNeighbourhood { get; set; }
        [Required]
        public string? ExpertPhone { get; set; }
        public DateTime SystemDate { get; set; }
        public DateTime UpdateSystemDate { get; set; }
        public int IsActive { get; set; }

        public ServiceCategoryModel? ServiceCategoryModel { get; set; }
        public ICollection<OfferModel>? OfferModels { get; set; }
    }
}
