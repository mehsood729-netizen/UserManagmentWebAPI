using UserManagmentWebAPI.Data.Enums;

namespace UserManagmentWebAPI.DTO_s
{
    public class GetUserDTO
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public Rule Role { get; set; } = Rule.User;
    }
}
