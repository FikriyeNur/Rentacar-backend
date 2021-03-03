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
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [FluentValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("Color.Add")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        [SecuredOperation("Color.Delete")]
        public IResult Delete(Color color)
        {
            if (color != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(ColorMessages.ColorDeleted);
            }
            return new ErrorResult(ColorMessages.FailedColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Color>>(result);
            }
            return new ErrorDataResult<List<Color>>(result, ColorMessages.FailedColorListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(b => b.ColorId == colorId);
            if (result != null)
            {
                return new SuccessDataResult<Color>(result);
            }
            return new ErrorDataResult<Color>(result, ColorMessages.FailedColorById);
        }

        [FluentValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("Color.Update")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }
    }
}
