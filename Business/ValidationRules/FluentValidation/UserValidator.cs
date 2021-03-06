using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).Length(3, 40);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).Length(3, 40);
            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.EMail).EmailAddress();
        }
    }
}
