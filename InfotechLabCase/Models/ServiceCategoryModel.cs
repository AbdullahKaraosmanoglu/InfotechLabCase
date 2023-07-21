using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class ServiceCategoryModel
    {
        [Key]
        public int ServiceCategoryId { get; set; }
        [Required]
        public string? ServiceCategoryName { get; set; }
        [Required]
        public int ServicePrice { get; set; }
        public DateTime SystemDate { get; set; }

        public ICollection<ExpertModel>? ExpertModels { get; set; }
    }
}
