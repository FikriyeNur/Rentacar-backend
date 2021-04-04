using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<CreditCard>
    {
        //List<PaymentDetailDto> GetAllPaymentDetails(Expression<Func<PaymentDetailDto, bool>> filter = null);
        //PaymentDetailDto GetByIdDto(int paymentId);
    }
}
