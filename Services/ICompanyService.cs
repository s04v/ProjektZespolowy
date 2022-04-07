namespace FindJobWebApi.Services
{
    public interface ICompanyService
    {
        public void SignIn();

        public void SignUp();

        public void SubscribeCompany();

        public void GetCompanies();

        public void GetVacanciesByCompany();

        public void GetProfile();

        public void AddProfile();

        public void UploadCompanyPhoto();
    }
}
