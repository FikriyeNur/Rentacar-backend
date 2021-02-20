using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) // IEntity yerine object verme nedenimiz Dto class'larını da kullanabilelim diye.
        {
            var result = validator.Validate(new ValidationContext<object>(entity));
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
