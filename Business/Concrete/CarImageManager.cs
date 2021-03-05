using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [FluentValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(CarImageMessage.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            if (carImage != null)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(CarImageMessage.CarImageDeleted);
            }
            return new ErrorResult(CarImageMessage.FailedCarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new ErrorDataResult<List<CarImage>>(result, CarImageMessage.FailedCarImageListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new ErrorDataResult<List<CarImage>>(result, CarImageMessage.FailedCarImageListed);
        }

        [FluentValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Update(carImage);
            return new SuccessResult(CarImageMessage.CarImageUpdated);
        }

        private IResult CheckCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(CarImageMessage.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
