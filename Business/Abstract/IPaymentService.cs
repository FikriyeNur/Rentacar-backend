using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int paymentId);
        IDataResult<List<PaymentDetailDto>> GetAllPaymentDetails();
        IDataResult<PaymentDetailDto> GetByIdDto(int paymentId);
        IResult VerifyCard(Payment payment);
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
    }
}
