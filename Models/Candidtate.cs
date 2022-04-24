using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class Candidtate
    {
        public ulong Id { get; set; }
        public ulong VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public ulong UserId { get; set; }
        public virtual User User { get; set; }
    }
}
