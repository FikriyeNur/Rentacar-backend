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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [FluentValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("rental.add, admin")]
        public IResult Add(Rental rental)
        {
            if (_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(RentalMessages.FailedRentalInformation);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }

        [SecuredOperation("rental.delete, admin")]

        public IResult Delete(Rental rental)
        {
            if (rental != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(RentalMessages.RentalDeleted);
            }
            return new ErrorResult(RentalMessages.FailedRentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Rental>>(result);
            }
            return new ErrorDataResult<List<Rental>>(result, RentalMessages.FailedRentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            var result = _rentalDal.GetAllRentalDetails();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(result);
            }
            return new ErrorDataResult<List<RentalDetailDto>>(result, RentalMessages.FailedRentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(r => r.Id == rentalId);
            if (result != null)
            {
                return new SuccessDataResult<Rental>(result);
            }
            return new ErrorDataResult<Rental>(result);
        }

        public IDataResult<RentalDetailDto> GetDetailById(int rentalId)
        {
            var result = _rentalDal.GetRentalDetails(rentalId);
            if (result != null)
            {
                return new SuccessDataResult<RentalDetailDto>(result);
            }
            return new ErrorDataResult<RentalDetailDto>(result);
        }

        public IResult IsCarAvailable(int carId)
        {
            var result = _rentalDal.IsCarAvailable(carId);
            if (result)
            {
                return new SuccessResult(RentalMessages.RentalAvaible);
            }
            return new ErrorResult(RentalMessages.FailedRentalInformation);

        }

        [FluentValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("rental.update, admin")]

        public IResult Update(Rental rental)
        {
            if (_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(RentalMessages.FailedRentalInformation);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }
    }
}
