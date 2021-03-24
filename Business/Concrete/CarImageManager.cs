using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

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
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(CarImageMessage.CarImageAdded);
        }

        [FluentValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var resultPath = $@"{_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath}";
            carImage.ImagePath = FileHelper.Update(resultPath, file);
            carImage.Date = DateTime.Now;

            if (carImage != null)
            {
                _carImageDal.Update(carImage);
                return new SuccessResult(CarImageMessage.CarImageUpdated);
            }
            return new ErrorResult(CarImageMessage.FailedCarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            var resultPath = $@"{_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath}";
            FileHelper.Delete(resultPath);

            if (resultPath != null)
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
            var result = _carImageDal.Get(ci => ci.Id == carImageId);
            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }
            return new ErrorDataResult<CarImage>(result, CarImageMessage.FailedCarImagesById);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            string path = @".\Default.png";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = path
            });
            return new SuccessDataResult<List<CarImage>>(carImage);
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
