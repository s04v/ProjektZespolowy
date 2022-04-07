using FindJobWebApi.DTOs;

namespace FindJobWebApi.Services
{
    public interface ICompanyService
    {
        public void SignIn();

        public string SignUp(CreateCompanyDTO companyDTO);

        public void SubscribeCompany();

        public void GetCompanies();

        public void GetVacanciesByCompany();

        public void GetProfile();

        public void AddProfile();

        public void UploadCompanyPhoto();
    }
}
