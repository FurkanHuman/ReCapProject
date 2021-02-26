using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).NotNull().MinimumLength(8);
            RuleFor(u => u.Email).EmailAddress().NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2).NotNull();
            RuleFor(u => u.LastName).MinimumLength(2).NotNull();
        }
    }
}
