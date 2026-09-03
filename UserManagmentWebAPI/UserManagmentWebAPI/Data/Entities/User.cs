using System.ComponentModel.DataAnnotations;
using UserManagmentWebAPI.Data.Enums;

namespace UserManagmentWebAPI.Data.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public Rule Role { get; set; } = Rule.User;
        public int OTP { get; set; }
        public byte[] Hash { get; set; } = [];
        public byte[] Salt { get; set; } = [];
    }
}
