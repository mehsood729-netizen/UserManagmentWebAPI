using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagmentWebAPI.DTO_s;
using UserManagmentWebAPI.Services.Interface;
using UserManagmentWebAPI.Utilities;

namespace UserManagmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IPasswordEncryptor _passwordEncryptor;
       /// private readonly IJWTService _jwtService;
        public AuthController(IAuthenticationServices authServices,IPasswordEncryptor passwordEncryptor)
        {
            _authenticationServices = authServices;
            _passwordEncryptor = passwordEncryptor;
           // _jwtService = service;
        }


        [HttpPost("User-Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO request)
        {
          var response =  await _authenticationServices.LoginAsync(request);
            if(!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
            

        [HttpPost("UserRegistration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO request)
        {
           var response = await _authenticationServices.UserRegisterAsync(request);
            if(!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Created("/Auth/UserRegistration", response);
        }


    }
}
