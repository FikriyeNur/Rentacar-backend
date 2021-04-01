using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserId).GreaterThan(0);
            RuleFor(p => p.CardNameSurname).NotEmpty();
            RuleFor(p => p.CardNameSurname).MinimumLength(6);
            RuleFor(p => p.CardNumber).NotEmpty();
            RuleFor(p => p.CardNumber).Length(16);
            RuleFor(p => p.CardExpirationDateMonth).NotEmpty();
            RuleFor(p => p.CardExpirationDateMonth).Length(2);
            RuleFor(p => p.CardExpirationDateYear).NotEmpty();
            RuleFor(p => p.CardExpirationDateYear).Length(4);
            RuleFor(p => p.CardCvv).NotEmpty();
            RuleFor(p => p.CardCvv).Length(3);
        }
    }
}
