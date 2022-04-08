using FindJobWebApi.DTOs;
using FindJobWebApi.Models;
using FindJobWebApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FindJobWebApi.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly ITokenService _tokenService;

        public CompanyController(ICompanyService service, ITokenService tokenService)
        {
            _service = service;
           _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<string>> Signin([FromBody] LoginCompanyDTO companyDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var result = _service.SignIn(companyDTO);


            if (!int.TryParse(result, out int id))
            {
                return result;
            }

            var token = _tokenService.generateToken(id, "Company");

            var claims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Role, "Company"),
                new Claim(ClaimTypes.Name, token)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookie", claimsPrincipal);

            return token;

        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<string>> SignUp([FromBody] CreateCompanyDTO companyDTO)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            var result = _service.SignUp(companyDTO);
            return result;
        }

        [Authorize(Roles = "User")]
        [HttpPost("{id}/subscribe")]
        public async Task<ActionResult<string>> SubscribeToNewVacancies([FromRoute] int id)
        {
            
            return "SubscribeToNewVacancies";
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetCompanyById([FromRoute] int id)
        {
            return $"GetCompanyById : {id}";
        }
        [HttpGet("list")]
        public async Task<ActionResult<string>> GetAllCompaies()
        {
            return "GetAllCompaies";
        }
        [HttpGet("{id}/job")]
        public async Task<ActionResult<string>> ListOfVacanciesOfCompany([FromRoute] int id)
        {
            return "ListOfVacanciesOfCompany";
        }
        [HttpGet("profile")]
        public async Task<ActionResult<string>> GetCompanyProfile()
        {


            return "GetCompanyProfile";
        }
        [HttpPost("profile")]
        public async Task<ActionResult<string>> AddDataAboutCompany()
        {
            return "AddDataAboutCompany";
        }

        [HttpPut("profile/upload")]
        public async Task<ActionResult<string>> UploadCompanyPhoto()
        {
            return "UploadCompanyPhoto";
        }
    }
}
