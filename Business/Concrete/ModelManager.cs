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
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [FluentValidationAspect(typeof(ModelValidator))]
        [SecuredOperation("model.add, admin")]

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(ModelMessages.ModelAdded);
        }

        [SecuredOperation("model.delete, admin")]

        public IResult Delete(Model model)
        {
            if (model != null)
            {
                _modelDal.Delete(model);
                return new SuccessResult(ModelMessages.ModelDeleted);
            }
            return new ErrorResult(ModelMessages.FailedModelDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            var result = _modelDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Model>>(result);
            }
            return new ErrorDataResult<List<Model>>(result, ModelMessages.FailedModelListed);
        }

        public IDataResult<Model> GetById(int modelId)
        {
            var result = _modelDal.Get(b => b.ModelId == modelId);
            if (result != null)
            {
                return new SuccessDataResult<Model>(result);
            }
            return new ErrorDataResult<Model>(result, ModelMessages.FailedModelById);
        }

        public IDataResult<List<ModelDetailDto>> GetAllModelDetails()
        {
            var result = _modelDal.GetAllModelDetails();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<ModelDetailDto>>(result);
            }
            return new ErrorDataResult<List<ModelDetailDto>>(result, ModelMessages.FailedModelListed);
        }

        [FluentValidationAspect(typeof(ModelValidator))]
        [SecuredOperation("model.update, admin")]

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(ModelMessages.ModelUpdated);
        }
    }
}
