using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InfotechLabCase.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int NeighbourhoodId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerSurname { get; set; }
        [Required]
        [MaxLength(10)]
        public string CustomerPhone { get; set; }
        [Required]
        [MaxLength(10)]
        public string CustomerPostCode { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }
        public int IsActive { get; set; }
        [Required, MaxLength(500)]
        public string AddressCustomer { get; set; }
    }
}
