using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, RentACarContext>, IPaymentDal
    {
        public List<PaymentDetailDto> GetAllPaymentDetails(Expression<Func<PaymentDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Payments
                             join u in context.Users
                             on p.UserId equals u.UserId
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new PaymentDetailDto
                             {
                                 PaymentId = p.PaymentId,
                                 UserId = u.UserId,
                                 CompanyName=c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.EMail,
                                 CardNumber = p.CardNumber,
                                 CardLimit=p.CardLimit
                             };
                if (filter == null)
                {
                    return result.ToList();
                }
                return result.Where(filter).ToList();
            }
        }

        public PaymentDetailDto GetByIdDto(int paymentId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Payments
                             join u in context.Users
                             on p.UserId equals u.UserId
                             join c in context.Customers
                           on u.UserId equals c.UserId
                             select new PaymentDetailDto
                             {
                                 PaymentId = p.PaymentId,
                                 UserId = u.UserId,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.EMail,
                                 CardNumber = p.CardNumber,
                                 CardLimit = p.CardLimit
                             };
                return result.FirstOrDefault(p => p.PaymentId == paymentId);
            }
        }
    }
}