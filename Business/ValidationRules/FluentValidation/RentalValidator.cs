﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotNull();
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r => r.CustomerId).NotNull();
        }
    }
}
