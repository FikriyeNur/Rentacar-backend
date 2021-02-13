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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(RentalMessages.RentalAdded);
            }
            else
            {
                return new ErrorResult(RentalMessages.FailedRentalInformation);
            }
        }

        public IResult Delete(Rental rental)
        {
            if (rental != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(RentalMessages.RentalDeleted);
            }
            else
            {
                return new ErrorResult(RentalMessages.FailedRentalDeleted);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Rental>>(result);
            }
            else
            {
                return new ErrorDataResult<List<Rental>>(result, RentalMessages.FailedRentalListed);
            }
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(r => r.Id == rentalId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(result);
            }
            else
            {
                return new ErrorDataResult<Rental>((result), RentalMessages.FailedRentalById);
            }
        }

        public IResult Uptade(Rental rental)
        {
            if (rental != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(RentalMessages.RentalUpdated);
            }
            else
            {
                return new ErrorResult(RentalMessages.FailedRentalInformation);
            }
        }
    }
}
