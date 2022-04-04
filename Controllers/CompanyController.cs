using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobWebApi.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
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
