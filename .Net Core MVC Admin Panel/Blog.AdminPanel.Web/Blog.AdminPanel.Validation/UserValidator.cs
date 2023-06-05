using Blog.AdminPanel.ViewModel;
using FluentValidation;

namespace Blog.AdminPanel.Validation
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty()
                .When(x => x.Action == "Register")
                .WithMessage("Username must not be empty.")
                .MaximumLength(50).MinimumLength(5)
                .WithMessage("Username must be between 5 and 50 characters.");

            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password must not be empty.")
                .MaximumLength(40).MinimumLength(3)
                .WithMessage("Password must be between 3 and 30 characters.");

            RuleFor(r => r.Email).NotEmpty()
                .EmailAddress();
        }
    }
}
