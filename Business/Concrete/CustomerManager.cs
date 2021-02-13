using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(CustomerMessages.CustomerAdded);
            }
            else
            {
                return new ErrorResult(CustomerMessages.FailedCustomerInformation);
            }
        }

        public IResult Delete(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(CustomerMessages.CustomerDeleted);
            }
            else
            {
                return new ErrorResult(CustomerMessages.FailedCustomerDeleted);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Customer>>(result);
            }
            else
            {
                return new ErrorDataResult<List<Customer>>(result, CustomerMessages.FailedCustomerListed);

            }
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var result = _customerDal.Get(c => c.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            else
            {
                return new ErrorDataResult<Customer>(result, CustomerMessages.FailedCustomerById);

            }
        }

        public IResult Uptade(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Update(customer);
                return new SuccessResult(CustomerMessages.CustomerUpdated);
            }
            else
            {
                return new ErrorResult(CustomerMessages.FailedCustomerInformation);
            }
        }
    }
}
