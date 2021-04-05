using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CartValidator:AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(ca=>ca.CartNumber).MinimumLength(16).MaximumLength(16).NotNull();
            RuleFor(ca => ca.CVV).NotNull();
            RuleFor(ca => ca.Name).NotNull();
            RuleFor(ca => ca.LastName).NotNull();
            RuleFor(ca => ca.Month).NotNull();
            RuleFor(ca => ca.Year).NotNull();
            RuleFor(ca => ca.TotalPrice).NotNull().NotEmpty();
        }
    }
}
