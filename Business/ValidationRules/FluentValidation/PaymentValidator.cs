using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<CreditCard>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.CardNameSurname).NotEmpty();
            RuleFor(c => c.CardNameSurname).MinimumLength(6);
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.CardNumber).Length(16);
            RuleFor(c => c.CardExpirationMonth).NotEmpty();
            RuleFor(c => c.CardExpirationMonth).Length(2);
            RuleFor(c => c.CardExpirationYear).NotEmpty();
            RuleFor(c => c.CardExpirationYear).Length(4);
            RuleFor(c => c.CardSecurityNumber).NotEmpty();
            RuleFor(c => c.CardSecurityNumber).Length(3);
        }
    }
}
