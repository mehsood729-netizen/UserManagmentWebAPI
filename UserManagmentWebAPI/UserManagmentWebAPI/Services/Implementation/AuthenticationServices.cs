using Microsoft.AspNetCore.Identity;
using UserManagmentWebAPI.API_Response;
using UserManagmentWebAPI.DTO_s;
using UserManagmentWebAPI.Extensions.Mappers;
using UserManagmentWebAPI.Repositories.Interface;
using UserManagmentWebAPI.Services.Interface;

namespace UserManagmentWebAPI.Services.Implementation
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAuthRepository _authRepo;
        private readonly IPasswordEncryptor _passwordEncryptor;
        public AuthenticationServices(IAuthRepository authRepository, IPasswordEncryptor passwordEncryptor)
        {
            _authRepo = authRepository;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<APIResponse<string>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _authRepo.LoginAsync(loginDTO.Identifier);
            if (user is not null)
            {
                var response = _passwordEncryptor.VerifyPassword(loginDTO.password, user.Hash, user.Salt);
                if (response)
                {
                    return APIResponse<string>.SuccessResponse("Login Successfully");
                }
                return APIResponse<string>.ErrorResponse("Invalid Creadentials");
            }
            return APIResponse<string>.ErrorResponse("Invalid Creadentials");
        }

        public async Task<APIResponse<string>> UserRegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            {
                _passwordEncryptor.PasswordHashAndSalt(userRegisterDTO.Password, out byte[] hash, out byte[] salt);
                var user = userRegisterDTO.Map();
                user.Hash = hash;
                user.Salt = salt;
                var userdata = await _authRepo.UserRegistration(user);

                if (userdata != null)
                {
                    if (userdata.UserName == userRegisterDTO.UserName)
                    {
                        return APIResponse<string>.ErrorResponse("UserName Already Exist");
                    }
                    if (userdata.Email == userRegisterDTO.Email)
                    {
                        return APIResponse<string>.ErrorResponse("Email Already Exist");

                    }
                    if (userdata.Contact == userRegisterDTO.Contact)
                    {
                        return APIResponse<string>.ErrorResponse("Contact Already Exist");
                    }
                }

                return APIResponse<string>.SuccessResponse("User Register Successfully");
            }
        }
    }
}

