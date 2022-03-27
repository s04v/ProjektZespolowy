using namespace FindJobWebApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }
        
        [HttpPost]
        public Task<ActionResult> Signin()
        {
            return "SignIn";
        }
    }

}