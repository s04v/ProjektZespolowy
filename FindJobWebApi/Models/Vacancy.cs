using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        [Required]
        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Requirements { get; set; }
        [Required]
        public string Responsibilities { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime UpdateTime { get; set; }
        
    }
}
