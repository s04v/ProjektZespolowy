using FindJobWebApi.DTOs;

namespace FindJobWebApi.Services
{
    public interface IVacancyService
    {
        public string AddNewVacancy(CreateVacancyDTO vacancyDTO);

        public string ModifyVacancy(ulong id, CreateVacancyDTO vacancyDTO);
    }
}
