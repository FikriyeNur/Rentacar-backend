using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        List<PaymentDetailDto> GetAllPaymentDetails(Expression<Func<PaymentDetailDto, bool>> filter = null);
        PaymentDetailDto GetByIdDto(int paymentId);
    }
}
