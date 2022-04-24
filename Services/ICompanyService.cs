using FindJobWebApi.DTOs;
using FindJobWebApi.Models;

namespace FindJobWebApi.Services
{
    public interface ICompanyService
    {
        public string SignIn(LoginCompanyDTO companyDTO);

        public string SignUp(CreateCompanyDTO companyDTO);

        public void SubscribeCompany();

        public IEnumerable<CompanyDTO> GetCompanies();

        public IEnumerable<VacancyDTO> GetVacanciesByCompany(ulong id);

        public CompanyDTO GetProfile(ulong id);

        public string AddProfile(ulong id, ModifyCompanyDTO dto);

        public void UploadCompanyPhoto();

        public CompanyDTO GetCompanyById(ulong id);
    }
}
