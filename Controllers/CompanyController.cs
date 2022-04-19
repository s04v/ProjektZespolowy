using FindJobWebApi.DTOs;
using FindJobWebApi.Models;
using FindJobWebApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json.Serialization;
using FindJobWebApi.Response;
using FindJobWebApi.JWTLogic;

namespace FindJobWebApi.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly ITokenService _tokenService;

        private readonly ICookieService _cookieService;

        public CompanyController(ICompanyService service, ITokenService tokenService, ICookieService cookieService)
        {
            _service = service;
           _tokenService = tokenService;
            _cookieService = cookieService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<string>> Signin([FromBody] LoginCompanyDTO companyDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return BadRequest(ResponseConvertor.GetResult("error", errors));
            }
            var result = _service.SignIn(companyDTO);


            if (!int.TryParse(result, out int id))
            {
                return BadRequest(ResponseConvertor.GetResult("error", result));
            }

            var token = _tokenService.generateToken(id, "Company");

            var claimsPrincipal = _cookieService.GetClaimsPrincipal("Company", token);
            await HttpContext.SignInAsync("Cookie", claimsPrincipal);

            return Ok(ResponseConvertor.GetResult("OK", token));    
        }
        #region SignUp
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<string>> SignUp([FromBody] CreateCompanyDTO companyDTO)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(ResponseConvertor.GetResult("error", errors));
            }

            var result = _service.SignUp(companyDTO);

            if (!result.Equals("OK")) return Conflict(ResponseConvertor.GetResult("error", result));
            
            return Ok(ResponseConvertor.GetResult("OK", result));
        }
        #endregion

        #region Subscribe
        [HttpPost("{id}/subscribe")]
        public async Task<ActionResult<string>> SubscribeToNewVacancies([FromRoute] int id)
        {
            
            return "SubscribeToNewVacancies";
        }
        #endregion

        #region Get Company By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyById([FromRoute] int id)
        {
            if (id < 1) return BadRequest(ResponseConvertor.GetResult("error", "impossible Id value"));

            var company = _service.GetCompanyById(id);
            return Ok(ResponseConvertor.GetResult("OK", company));
        }
        #endregion

        #region Get Companies
        [HttpGet("list")]
        public async Task<ActionResult<string>> GetAllCompanies()
        {
            return "GetAllCompaies";
        }
        #endregion

        #region Get List of Vacancies
        [HttpGet("{id}/job")]
        public async Task<ActionResult<string>> ListOfVacanciesOfCompany([FromRoute] int id)
        {
            return "ListOfVacanciesOfCompany";
        }
        #endregion

        #region Get Profile
        [Authorize(Roles = "Company")]
        [HttpGet("profile")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyProfile()
        {
            var currentProfile = User.Identity?.Name;
            if(string.IsNullOrEmpty(currentProfile?.ToString()))
            {
                return NotFound(ResponseConvertor.GetResult("error", "Token is empty"));
            }

            var currentId = currentProfile.ToString().parseToken();
            var company = _service.GetProfile(currentId);
            if(company == null)
            {
                return NotFound(ResponseConvertor.GetResult("error", "Problem occured by company ID"));
            }
            return Ok(ResponseConvertor.GetResult("OK", company));
        }
        #endregion

        #region Add Data About Profile
        [HttpPost("profile")]
        public async Task<ActionResult<string>> AddDataAboutCompany()
        {
            return "AddDataAboutCompany";
        }
        #endregion

        #region Upload Company Photo
        [HttpPut("profile/upload")]
        public async Task<ActionResult<string>> UploadCompanyPhoto()
        {
            return "UploadCompanyPhoto";
        }
        #endregion
    }
}
