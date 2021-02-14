using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Uptade(Rental rental);
        IResult Delete(Rental rental);
    }
}
