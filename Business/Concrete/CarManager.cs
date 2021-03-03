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
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        // Cross Cutting Concerns : Validation, Log, Cache, Performans, Transaction, Authorization => AOP (Aspect Oriented Programming) kullanarak bu işlemleri yapacağız. AOP sadece bu işlemleri yaparken kullanılmalıdır.

        [FluentValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Car.Add")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(CarMessages.CarAdded);
        }

        [SecuredOperation("Car.Delete")]
        public IResult Delete(Car car)
        {
            if (car != null)
            {
                _carDal.Delete(car);
                return new SuccessResult(CarMessages.CarDeleted);
            }
            return new ErrorResult(CarMessages.FailedCarDeleted);

        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            var result = _carDal.GetAllCarDetails();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailDto>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.Get(c => c.CarId == carId);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>(result, CarMessages.FailedCarById);
        }

        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            var result = _carDal.GetCarDetail(carId);
            if (result != null)
            {
                return new SuccessDataResult<CarDetailDto>(result);
            }
            return new ErrorDataResult<CarDetailDto>(result, CarMessages.FailedCarById);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);

            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<List<Car>> GetCarsByModelId(int modelId)
        {
            var result = _carDal.GetAll(c => c.ModelId == modelId);
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<List<Car>> GetComfortCars()
        {
            var result = _carDal.GetAll(c => c.Description.Contains("Konfor"));
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<List<Car>> GetEconomicCars()
        {
            var result = _carDal.GetAll(c => c.Description.Contains("Eko"));
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        public IDataResult<List<Car>> GetLuxuryCars()
        {
            var result = _carDal.GetAll(c => c.Description.Contains("Lüks"));
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Car>>(result);
            }
            return new ErrorDataResult<List<Car>>(result, CarMessages.FailedCarListed);
        }

        [FluentValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Car.Update")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(CarMessages.CarUpdated);
        }
    }
}
