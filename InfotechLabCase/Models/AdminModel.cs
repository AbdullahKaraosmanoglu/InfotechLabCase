using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class AdminModel
    {
        [Key]
        public int AdminId { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int OfferId { get; set; }
        public int RoleId { get; set; }
        public int ServiceCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string AdminEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string AdminPassword { get; set; }
        [Required]
        [MaxLength(50)]
        public string AdminName { get; set; }
        [Required]
        [MaxLength(50)]
        public string AdminSurname { get; set; }
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
        public int IsActive { get; set; }
    }
}
