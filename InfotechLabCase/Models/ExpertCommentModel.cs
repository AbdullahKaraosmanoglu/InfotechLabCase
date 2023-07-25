using System.ComponentModel.DataAnnotations;

namespace InfotechLabCase.Models
{
    public class ExpertCommentModel
    {
        [Key] 
        public int ExpertCommentId { get; set; }
        [Required]
        public int ExpertId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(350)]
        public string ExpertComment { get; set; }
        [Required]
        public DateTime SystemDate { get; set; }
        public DateTime? UpdateSystemDate { get; set; }

    }
}
