using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(PaymentMessages.PaymentAdded);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Payment>>(result);
            }
            return new ErrorDataResult<List<Payment>>(result, PaymentMessages.FailedPaymentListed);
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            var result = _paymentDal.Get(p => p.PaymentId == paymentId);
            if (result != null)
            {
                return new SuccessDataResult<Payment>(result);
            }
            return new ErrorDataResult<Payment>(result, PaymentMessages.FailedPaymentById);
        }

        public IDataResult<List<PaymentDetailDto>> GetAllPaymentDetails()
        {
            var result = _paymentDal.GetAllPaymentDetails();
            if (result != null)
            {
                return new SuccessDataResult<List<PaymentDetailDto>>(result);
            }
            return new ErrorDataResult<List<PaymentDetailDto>>(result, PaymentMessages.FailedPaymentListed);
        }

        public IDataResult<PaymentDetailDto> GetByIdDto(int paymentId)
        {
            var result = _paymentDal.GetByIdDto(paymentId);
            if (result != null)
            {
                return new SuccessDataResult<PaymentDetailDto>(result);
            }
            return new ErrorDataResult<PaymentDetailDto>(result, PaymentMessages.FailedPaymentById);
        }

        [FluentValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(PaymentMessages.PaymentUpdated);
        }

        public IResult Delete(Payment payment)
        {
            if (payment != null)
            {
                _paymentDal.Delete(payment);
                return new SuccessResult(PaymentMessages.PaymentDeleted);
            }
            return new ErrorResult(PaymentMessages.FailedPaymentDeleted);
        }

        public IResult VerifyCard(Payment payment)
        {
            var result = _paymentDal.Get(p => p.CardNameSurname == payment.CardNameSurname && p.CardNumber == payment.CardNumber && p.CardExpirationDateMonth == payment.CardExpirationDateMonth && p.CardExpirationDateYear == payment.CardExpirationDateYear && p.CardCvv == payment.CardCvv && p.CardLimit == payment.CardLimit);

            if (result !=null)
            {
                return new SuccessResult(PaymentMessages.VerifiedCard);
            }
            return new ErrorResult(PaymentMessages.FailedVerifiedCard);
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            var result = _paymentDal.GetAll(p => p.CardNumber == cardNumber);
            if(result != null)
            {
                return new SuccessDataResult<List<Payment>>(PaymentMessages.VerifiedCard);
            }
            return new ErrorDataResult<List<Payment>>(PaymentMessages.FailedVerifiedCard);
        }
    }
}
