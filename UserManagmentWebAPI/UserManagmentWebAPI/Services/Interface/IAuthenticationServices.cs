using UserManagmentWebAPI.API_Response;
using UserManagmentWebAPI.DTO_s;

namespace UserManagmentWebAPI.Services.Interface
{
    public interface IAuthenticationServices
    {
        Task<APIResponse<string>> UserRegisterAsync(UserRegisterDTO userRegisterDTO);
        Task<APIResponse<string>> LoginAsync(LoginDTO loginDTO);
    }
}
