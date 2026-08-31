using FluentValidation;
using UserManagmentWebAPI.DTO_s;

namespace UserManagmentWebAPI.Extensions.Validator
{
    public class ValidateUserRegisterDTO : AbstractValidator<UserRegisterDTO>
    {
        public ValidateUserRegisterDTO()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Is Required!")
                .EmailAddress().WithMessage("Please enter a valid email address");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required!")
                .MinimumLength(3).WithMessage("UserName is must be atleast 3 characters!")
                .MaximumLength(16).WithMessage("UserName  can't exceed 16 characters!")
                .Matches("^[a-zA-Z]+$").WithMessage("USerName must contain only letters");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters!")
                .MaximumLength(16).WithMessage("Password can't exceed 16 characters!")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter!")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter!")
                .Matches("[0-9]").WithMessage("Password must contain at least one number!")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character!");

        }
    }
}
