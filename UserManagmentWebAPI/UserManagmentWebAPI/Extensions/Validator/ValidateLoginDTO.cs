using FluentValidation;
using UserManagmentWebAPI.DTO_s;

namespace UserManagmentWebAPI.Extensions.Validator
{
    public class ValidateLoginDTO : AbstractValidator<LoginDTO>
    {
        public ValidateLoginDTO()
        {
            RuleFor(i => i.Identifier).NotEmpty().WithMessage("Identifier is required!");
            RuleFor(p => p.password).NotEmpty().WithMessage("Password is required!");
        }
    }
}
