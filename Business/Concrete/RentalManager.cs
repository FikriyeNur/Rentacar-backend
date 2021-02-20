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
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;

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
            ValidationTool.Validate(new RentalValidator(), rental);

            if (_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(RentalMessages.FailedRentalInformation);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
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

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            var result = _rentalDal.GetAllRentalDetails();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(result);
            }
            else
            {
                return new ErrorDataResult<List<RentalDetailDto>>(result, RentalMessages.FailedRentalListed);
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
                return new ErrorDataResult<Rental>(result);
            }
        }

        public IResult Update(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            if (_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(RentalMessages.FailedRentalInformation);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }
    }
}
