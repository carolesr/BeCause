using FluentValidation;
using UserService.Core.Requests;
using UserService.Domain.Entities;

namespace UserService.Core.Validations
{
    public class UserValidator : AbstractValidator<CreateUserRequest>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty();
            RuleFor(u => u.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(u => u.Phone).NotNull().NotEmpty();
            RuleFor(u => u.CPF).NotNull().NotEmpty(); //fazer validaçao de cpf
            RuleFor(u => u.Birthday).NotNull().NotEmpty();
        }
    }
}
