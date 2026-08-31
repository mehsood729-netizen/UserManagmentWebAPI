using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagmentWebAPI.DTO_s;
using UserManagmentWebAPI.Services.Interface;

namespace UserManagmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;
        public AuthController(IAuthenticationServices authServices)
        {
            _authenticationServices = authServices;
        }


        [HttpPost("UserLogin")]
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
