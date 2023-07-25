using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class DistrictModel
    {
        [Key]
        public int DistrictId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string DistrictName { get; set; }
    }
}
