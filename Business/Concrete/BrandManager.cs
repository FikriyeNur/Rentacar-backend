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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(BrandMessages.BrandAdded);
            }
            else
            {
                return new ErrorResult(BrandMessages.FailedBrandInformation);
            }
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
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(BrandMessages.BrandUpdated);
            }
            else
            {
                return new ErrorResult(BrandMessages.FailedBrandInformation);
            }
        }
    }
}
