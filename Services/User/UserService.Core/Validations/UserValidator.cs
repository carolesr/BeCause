using FluentValidation;
using UserService.Domain.Entities;

namespace UserService.Core.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty();
            RuleFor(u => u.Email).NotNull().NotEmpty();
            RuleFor(u => u.Phone).NotNull().NotEmpty();
        }
    }
}
