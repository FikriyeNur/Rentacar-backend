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
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessResult(BrandMessages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(BrandMessages.BrandDeleted);
            }
            else
            {
                return new ErrorResult(BrandMessages.FailedBrandDeleted);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Brand>>(result);
            }
            else
            {
                return new ErrorDataResult<List<Brand>>(result, BrandMessages.FailedBrandListed);
            }
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(b => b.BrandId == brandId);
            if (result != null)
            {
                return new SuccessDataResult<Brand>(result);
            }
            else
            {
                return new ErrorDataResult<Brand>(result, BrandMessages.FailedBrandById);
            }
        }

        public IResult Update(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);

            _brandDal.Update(brand);
            return new SuccessResult(BrandMessages.BrandUpdated);
        }
    }
}
