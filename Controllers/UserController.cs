using FindJobWebApi.DTOs;
using FindJobWebApi.JWTLogic;
using FindJobWebApi.Response;
using FindJobWebApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobWebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ITokenService _tokenService;

        private readonly ICookieService _cookieService;

        public UserController(IUserService service, ITokenService tokenService, ICookieService cookieService)
        {
            _service = service;
            _tokenService = tokenService;
            _cookieService = cookieService;
        }


        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<string>> Signin([FromBody] LoginUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return BadRequest(ResponseConvertor.GetResult("error", errors));
            }
            var result = _service.SignIn(userDTO);


            if (!int.TryParse(result, out int id))
            {
                return BadRequest(ResponseConvertor.GetResult("error", result));
            }

            var token = _tokenService.generateToken(id, "User");

            var claimsPrincipal = _cookieService.GetClaimsPrincipal("User", token);
            await HttpContext.SignInAsync("Cookie", claimsPrincipal);

            return Ok(ResponseConvertor.GetResult("OK", token));    
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<string>> SignUp([FromBody] CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(ResponseConvertor.GetResult("error", errors));
            }

            var result = _service.SignUp(userDTO);

            if (!result.Equals("OK")) return Conflict(ResponseConvertor.GetResult("error", result));

            return Ok(ResponseConvertor.GetResult("OK", result));
        }


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

        [Authorize(Roles="User")]
        [HttpGet("profile")]
        public async Task<ActionResult<string>> GetUserProfile([FromHeader] string authorization)
        {
            //var currentUser = User.Identity;

            if (string.IsNullOrEmpty(authorization))
                return NotFound(ResponseConvertor.GetResult("error", "Token is empty"));

            var userId = authorization.parseToken();

            var user = _service.GetUser(userId);

            if(user == null)
                return NotFound(ResponseConvertor.GetResult("error", "Problem occured by user ID"));

            return Ok(ResponseConvertor.GetResult("OK", user));
        }


        [HttpPost("profile")]
        public async Task<ActionResult<string>> AddUserData([FromHeader] string authorization, ModifyUserDTO dto)
        {
            //var currentUser = User.Identity;

            if (string.IsNullOrEmpty(authorization))
                return NotFound(ResponseConvertor.GetResult("error", "Token is empty"));

            var currentId = authorization.parseToken();

            var result = _service.AddProfile(currentId, dto);

            if (result.Equals("Error")) 
                return NotFound(ResponseConvertor.GetResult("error", "Problem occured by company ID"));

            return Ok(ResponseConvertor.GetResult("OK", result));

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
