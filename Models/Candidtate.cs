using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class Candidtate
    {
        public int Id { get; set; }
        [Required]
        public int VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
