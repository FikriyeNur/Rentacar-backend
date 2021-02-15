using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails();
        IDataResult<Customer> GetById(int customerId);
        IResult Add(Customer customerId);
        IResult Update(Customer customerId);
        IResult Delete(Customer customerId);
    }
}
