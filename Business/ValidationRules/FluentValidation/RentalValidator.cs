using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r=> r.CarId).GreaterThan(0);
            RuleFor(r => r.CustomerId).NotNull();
            RuleFor(r => r.CustomerId).GreaterThan(0);
            RuleFor(r=>r.RentDate).NotEmpty();
        }
    }
}
