using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerPassword { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerSurname { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerCity { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerDistrict { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerNeighbourhood { get; set; }
        [Required]
        [MaxLength(10)]
        public string CustomerPhone { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
        public int IsActive { get; set; }
    }
}
