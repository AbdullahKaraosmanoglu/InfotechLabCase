using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
