using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).Length(4);
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ModelId).NotNull();
            RuleFor(c => c.ModelId).GreaterThan(0);
        }
    }
}
