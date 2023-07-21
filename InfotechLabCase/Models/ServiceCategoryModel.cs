using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class ServiceCategoryModel
    {
        [Key]
        public int ServiceCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ServiceCategoryName { get; set; }
        [Required]
        public int ServicePrice { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
    }
}
