using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidation:AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).Length(3, 30);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).Length(3, 30);
            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.EMail).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Length(4);
        }
    }
}
