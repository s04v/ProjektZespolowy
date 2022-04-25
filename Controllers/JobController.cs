using FindJobWebApi.DTOs;
using FindJobWebApi.JWTLogic;
using FindJobWebApi.Response;
using FindJobWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobWebApi.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly IVacancyService _service;
        private readonly ITokenService _tokenService;

        private readonly ICookieService _cookieService;

        public JobController(IVacancyService service, ITokenService tokenService, ICookieService cookieService)
        {
            _service = service;
            _tokenService = tokenService;
            _cookieService = cookieService;
        }

        [Authorize(Roles = "Company")]
        [HttpPost("add")]
        public async Task<ActionResult<string>> AddNewJob([FromBody]CreateVacancyDTO vacancyDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(ResponseConvertor.GetResult("error", errors));
            }

            var currentCompany = User.Identity;
            var currentCompanyId = Int32.MinValue;

            if (currentCompany == null || !Int32.TryParse(currentCompany.Name, out currentCompanyId))
                return NotFound(ResponseConvertor.GetResult("error", "Problem occured by token"));

            var result = _service.AddNewVacancy(currentCompanyId, vacancyDTO);

            if (!result.Equals("OK")) 
                return Conflict(ResponseConvertor.GetResult("error", result));

            return Ok(ResponseConvertor.GetResult("OK", result));
        }

        [Authorize(Roles = "Company")]
        [HttpPost("modify")]
        public async Task<ActionResult<string>> ModifyJob([FromHeader] string authorization, [FromBody] ModifyVacancyDTO vacancyDTO)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                return NotFound(ResponseConvertor.GetResult("error", "Token is empty"));
            }

            var companyId = authorization.parseToken();

            var result = _service.ModifyVacancy(companyId, vacancyDTO);//_service.ModifyVacancy(companyId, vacancyDTO);
            if (result.Equals("Error")) 
                return NotFound(ResponseConvertor.GetResult("error", "Problem occured by company ID"));

            return Ok(ResponseConvertor.GetResult("OK", result));
        }

        #region InProgress
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetJobById([FromRoute] int id)
        {
            return $"Job by Id {id}";
        }
        [HttpGet("search")]
        public async Task<ActionResult<string>> SearchJob()
        {
            return "SearchJob";
        }
        [HttpGet("apply")]
        public async Task<ActionResult<string>> ApplyJob()
        {
            return "ApplyJob";
        }
        #endregion
    }
}
