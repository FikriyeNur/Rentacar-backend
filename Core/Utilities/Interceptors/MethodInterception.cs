using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { } // method çalışmadan önce çalışır
        protected virtual void OnAfter(IInvocation ınvocation) { } // method çalıştıktan sonra çalışır
        protected virtual void OnException(IInvocation ınvocation, Exception ex) { } // method hata verdiğinde çalışır
        protected virtual void OnSuccess(IInvocation invocation) { }  // method başarılıysa çalışır

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }

    }
}
