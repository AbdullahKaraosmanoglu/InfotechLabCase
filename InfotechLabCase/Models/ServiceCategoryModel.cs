using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class ServiceCategoryModel
    {
        [Key]
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public int ServicePrice { get; set; }
    }
}
