using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustormerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerNeighbourhood { get; set; }
        public long CustomerPhone { get; set; }
        public DateTime CustomerTranDate { get; set; }
        public int IsActive { get; set; }
    }
}
