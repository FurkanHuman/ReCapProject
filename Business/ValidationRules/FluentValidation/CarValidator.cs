using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).LessThan(50).GreaterThan(10000).NotNull();
            RuleFor(c => c.ColorId).LessThan(0).NotNull();
            RuleFor(c => c.BrandId).LessThan(0).NotNull();
            RuleFor(c => c.Descriptions).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(c => c.ModelYear.Year).GreaterThanOrEqualTo(1998);
        }
    }
}
