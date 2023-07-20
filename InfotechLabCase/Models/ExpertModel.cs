using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class ExpertModel
    {
        [Key]
        public int ExpertId { get; set; }
        public int ExpertCategoryId { get; set; }
        public string ExpertEmail { get; set; }
        public string ExpertPassword { get; set; }
        public string ExpertName { get; set; }
        public string ExpertSurname { get; set; }
        public string ExpertCity { get; set; }
        public string ExpertDistrict { get; set; }
        public string ExpertNeighbourhood { get; set; }
        public long ExpertPhone { get; set; }
        public DateTime ExpertTranDate { get; set; }
        public int IsActive { get; set; }
    }
}
