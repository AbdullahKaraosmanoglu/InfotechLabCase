using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
        public int IsActive { get; set; }
    }
}
