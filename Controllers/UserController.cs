using Microsoft.AspNetCore.Mvc;

namespace FindJobWebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetUserById([FromRoute] int id)
        {
            return $"GetUserById : {id}";
        }
        [HttpGet("list")]
        public async Task<ActionResult<string>> GetUsers()
        {
            return "User List";
        }
        [HttpGet("profile")]
        public async Task<ActionResult<string>> GetUserProfile()
        {
            return "User Profile";
        }
        [HttpGet("profile/cv/create")]
        public async Task<ActionResult<string>> CreateCVForUser()
        {
            return "CreateCVForUser";
        }
        [HttpPut("profile/upload")]
        public async Task<ActionResult<string>> UploadUserProfile()
        {
            return "UploadUserProfile";
        }
       
    }
}
