using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        //[FluentValidationAspect(typeof(PaymentValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _paymentDal.Add(creditCard);
            return new SuccessResult(PaymentMessages.CardAdded);
        }

        [FluentValidationAspect(typeof(PaymentValidator))]
        public IResult Update(CreditCard creditCard)
        {
            _paymentDal.Update(creditCard);
            return new SuccessResult(PaymentMessages.CardUpdated);
        }

        public IResult Delete(CreditCard creditCard)
        {
            if (creditCard != null)
            {
                _paymentDal.Delete(creditCard);
                return new SuccessResult(PaymentMessages.CardDeleted);
            }
            return new ErrorResult(PaymentMessages.FailedCardDeleted);
        }
        public IDataResult<List<CreditCard>> GetAll()
        {
            var result = _paymentDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CreditCard>>(result);
            }
            return new ErrorDataResult<List<CreditCard>>(result, PaymentMessages.FailedCardListed);
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            var result = _paymentDal.Get(p => p.Id == creditCardId);
            if (result != null)
            {
                return new SuccessDataResult<CreditCard>(result);
            }
            return new ErrorDataResult<CreditCard>(result, PaymentMessages.FailedCardById);
        }
    }
}
