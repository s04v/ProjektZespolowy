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

        public void GetVacanciesByCompany();

        public CompanyDTO GetProfile(int id);

        public void AddProfile();

        public void UploadCompanyPhoto();

        public CompanyDTO GetCompanyById(int id);
    }
}
