using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class FluentValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            // gönderilen validatorType IValidator türünde değilse kullanıcıya hata mesajı döneriz :
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            // eğer hata almıyorsak bu işlemi gerçekleştiririz.
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation) // invocation = method
        {
            // reflection yapısıyla instance ürettik. Business'da ürettiğimiz validator'umuzu new'ledik.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            // Business'daki entity'mize (objemize) ulaştık.Validator'lar içinde bir tane nesne var o yüzden direk 0. yazdık.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            // metod'un argümanlarına ulaştık ve entityType olanı seçtik.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            // birden fazla olursa :
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
