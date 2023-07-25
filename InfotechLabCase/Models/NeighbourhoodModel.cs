using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class NeighbourhoodModel
    {
        [Key]
        public int NeighbourhoodId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public string NeighbourhoodName { get; set; }
    }
}
