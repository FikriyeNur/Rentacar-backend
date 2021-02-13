using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<List<Model>> GetAll();
        IDataResult<Model> GetById(int modelId);
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
        IDataResult<List<ModelDetailDto>> GetAllModelDetails();
    }
}
