using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
