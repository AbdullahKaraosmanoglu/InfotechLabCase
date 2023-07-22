using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfotechLabCase.Models
{
    public class ExpertModel
    {
        [Key]
        public int ExpertId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int ServiceCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertPassword { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertSurname { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertCity { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertDistrict { get; set; }
        [Required]
        [MaxLength(50)]
        public string ExpertNeighbourhood { get; set; }
        [Required]
        [MaxLength(10)]
        public string ExpertPhone { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
        public int IsActive { get; set; }
    }
}
