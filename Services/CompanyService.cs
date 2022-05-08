﻿using AutoMapper;
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
        public string AddProfile(int id,ModifyCompanyDTO dto)
        {
            var company = _context.Companies.SingleOrDefault(x => x.Id == id);
            if (company == null) return "Error";

            if(!string.IsNullOrEmpty(dto.Description)) company.Desciption = dto.Description;
            if(!string.IsNullOrEmpty(dto.CompanyName)) company.CompanyName = dto.CompanyName;

            if (IsAddressExist(dto.CompanyAddressId)) company.CompanyAddressId = dto.CompanyAddressId;

            if (!string.IsNullOrEmpty(dto.Website)) company.Website = dto.Website;
            if (!string.IsNullOrEmpty(dto.Password)) company.Password = dto.Password.getHash();

            _context.SaveChanges();

            return "OK";
        }

        public IEnumerable<CompanyDTO> GetCompanies()
        {
            var companies = _context.Companies.ToList();
            var mappedCompanies = _mapper.Map<List<CompanyDTO>>(companies);

            for(int i = 0; i < mappedCompanies.Count; i++)
            {
                var company = companies[i];
                if (!(company.CompanyAddressId == null || company.CompanyAddressId == 0))
                {
                    var address = _context.CompanyAddresses.SingleOrDefault(x => x.Id == company.CompanyAddressId);
                    if (address != null)
                    {
                        var mappedAddress = _mapper.Map<CompanyAddressDTO>(address);
                        mappedCompanies[i].CompanyAddress = mappedAddress;
                    }
                }  
            }
            return mappedCompanies;
        }

        public CompanyDTO GetCompanyById(int id)
        {
            var company = _context.Companies.SingleOrDefault(x => x.Id == id);
            if (company == null) return null;

            var mappedCompany = _mapper.Map<CompanyDTO>(company);
            if (!(company.CompanyAddressId == null || company.CompanyAddressId == 0))
            {
                var address = _context.CompanyAddresses.SingleOrDefault(x => x.Id == company.CompanyAddressId);
                if (address != null)
                {
                    var mappedAddress = _mapper.Map<CompanyAddressDTO>(address);
                    mappedCompany.CompanyAddress = mappedAddress;
                }
            }
            return mappedCompany;
        }

        public CompanyDTO GetProfile(int id)
        {
            var company = _context.Companies.SingleOrDefault(x => x.Id == id);
            if(company == null) return null;

            var mappedCompany = _mapper.Map<CompanyDTO>(company);
            if(!(company.CompanyAddressId == null || company.CompanyAddressId == 0))
            {
                var address = _context.CompanyAddresses.SingleOrDefault(x => x.Id == company.CompanyAddressId);
                if (address != null)
                {
                    var mappedAddress = _mapper.Map<CompanyAddressDTO>(address);
                    mappedCompany.CompanyAddress = mappedAddress;
                }
            }
            return mappedCompany;
        }

        public IEnumerable<VacancyDTO> GetVacanciesByCompany(int id)
        {
            var vacancies = _context.Vacancies.Where<Vacancy>(x => x.CompanyId == id);
            var mappedVacancies = _mapper.Map<List<VacancyDTO>>(vacancies);

            return mappedVacancies;
        }

        public string SignIn(LoginCompanyDTO companyDTO)
        {
           var currentCompany = _context.Companies.SingleOrDefault(x => x.Email.Equals(companyDTO.Email));
           var hashedPassword = companyDTO.Password.getHash();
            if (currentCompany == null || !hashedPassword.Equals(currentCompany.Password))
            {
                return "Login/Password is incorrect!";
            }
            return currentCompany.Id.ToString();
        }

        public string SignUp(CreateCompanyDTO companyDTO)
        {
            if (_context.Companies.Any(x => x.Email == companyDTO.Email))
            {
                return "Account with this email address already exists!";
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

        private bool IsAddressExist(int? addressId)
        {
            if (addressId == null || _context.Companies.SingleOrDefault(x => x.Id == addressId) == null)
                return false;
            return true;
        }
    }
}
