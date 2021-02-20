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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Add(color);
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (color != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(ColorMessages.ColorDeleted);
            }
            else
            {
                return new ErrorResult(ColorMessages.FailedColorDeleted);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Color>>(result);
            }
            else
            {
                return new ErrorDataResult<List<Color>>(result, ColorMessages.FailedColorListed);
            }
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(b => b.ColorId == colorId);
            if (result != null)
            {
                return new SuccessDataResult<Color>(result);
            }
            else
            {
                return new ErrorDataResult<Color>(result, ColorMessages.FailedColorById);
            }
        }

        public IResult Update(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Update(color);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }
    }
}
