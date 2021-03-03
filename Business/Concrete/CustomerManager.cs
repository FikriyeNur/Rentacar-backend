using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("Customer.Add")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }

        [SecuredOperation("Customer.Delete")]
        public IResult Delete(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(CustomerMessages.CustomerDeleted);
            }
            return new ErrorResult(CustomerMessages.FailedCustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Customer>>(result);
            }
            return new ErrorDataResult<List<Customer>>(result, CustomerMessages.FailedCustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails()
        {
            var result = _customerDal.GetAllCustomerDetails();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<CustomerDetailDto>>(result);
            }
            return new ErrorDataResult<List<CustomerDetailDto>>(result, CustomerMessages.FailedCustomerListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var result = _customerDal.Get(c => c.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            return new ErrorDataResult<Customer>(result, CustomerMessages.FailedCustomerById);
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("Customer.Update")]

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.CustomerUpdated);
        }
    }
}
