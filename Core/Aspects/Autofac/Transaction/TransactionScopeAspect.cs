using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        // Intercept kullanma nedenimiz transaction'u method'un yaşam döngüsünde kontrol etmek için seçtik.
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose(); // işlem başarısızsa yapılan işlemleri geri alır.
                    throw;
                }
            }
        }
    }
}
