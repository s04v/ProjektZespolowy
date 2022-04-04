using Microsoft.AspNetCore.Mvc;

namespace FindJobWebApi.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
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
        [HttpPost("add")]
        public async Task<ActionResult<string>> AddNewJob()
        {
            return "AddNewJob";
        }
    }
}
