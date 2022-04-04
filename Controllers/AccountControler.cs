using Microsoft.AspNetCore.Mvc;

namespace FindJobWebApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        
        [HttpPost("signin")]
        public async Task<ActionResult<string>> Signin()
        {
            return "SignIn";
        }

        [HttpPost("signup")]
        public async Task<ActionResult<string>> SignUp()
        {
            return "SignUp";
        }
    }

}