using AutoMapper;
using FindJobWebApi.DataBase;
using FindJobWebApi.DTOs;
using FindJobWebApi.Models;
using FindJobWebApi.Secure;
namespace FindJobWebApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public void AddProfile()
        {
            throw new NotImplementedException();
        }

        public void GetCompanies()
        {
            throw new NotImplementedException();
        }

        public void GetProfile()
        {
            throw new NotImplementedException();
        }

        public void GetVacanciesByCompany()
        {
            throw new NotImplementedException();
        }

        public void SignIn()
        {
            throw new NotImplementedException();
        }

        public string SignUp(CreateCompanyDTO companyDTO)
        {
            if (_context.Companies.Any(x => x.Email == companyDTO.Email))
            {
                return "Account with this email address already exists";
            }

            var currentFirm = _mapper.Map<Company>(companyDTO);
            currentFirm.Password = companyDTO.Password.getHash();
            _context.Companies.Add(currentFirm);
            _context.SaveChanges();
            return "OK";
        }

        public void SubscribeCompany()
        {
            throw new NotImplementedException();
        }

        public void UploadCompanyPhoto()
        {
            throw new NotImplementedException();
        }
    }
}
