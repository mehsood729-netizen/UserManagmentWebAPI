using UserManagmentWebAPI.Data.Entities;
using UserManagmentWebAPI.DTO_s;

namespace UserManagmentWebAPI.Extensions.Mappers
{
    public static class UserRegisterDTOToUser
    {
        public static User Map(this UserRegisterDTO userRegisterDTO)
        {
            return new User
            {

                UserId = Guid.NewGuid(),
                Contact = userRegisterDTO.Contact,
                Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.UserName,
            };
        }
    }
}
