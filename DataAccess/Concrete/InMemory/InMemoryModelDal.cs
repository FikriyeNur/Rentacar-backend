using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryModelDal : IModelDal
    {
        List<Model> _models;

       
        public InMemoryModelDal()
        {
            _models = new List<Model>
            {
                new Model {ModelId=1, BrandId=1, ModelName="Clio"},
                new Model {ModelId=2, BrandId=1, ModelName="Symbol"},
                new Model {ModelId=3, BrandId=2, ModelName="Egea"},
                new Model {ModelId=4, BrandId=2, ModelName="Panda"},
                new Model {ModelId=5, BrandId=3, ModelName="Duster"},
                new Model {ModelId=6, BrandId=3, ModelName="Sandero"}
            };
        }

        public void Add(Model model)
        {
            _models.Add(model);
        }

        public void Delete(Model model)
        {
            Model deletToModel = _models.SingleOrDefault(m => m.ModelId == model.ModelId);
            _models.Remove(deletToModel);
        }

        public Model Get(Expression<Func<Model, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Model> GetAll(Expression<Func<Model, bool>> filter = null)
        {
            return _models;
        }

        public List<ModelDetailDto> GetAllModelDetails()
        {
            throw new NotImplementedException();
        }

        public List<Model> GetById(int Id)
        {
            return _models.Where(m => m.ModelId == Id).ToList();
        }

        public ModelDetailDto GetModelDetail(int modelId)
        {
            throw new NotImplementedException();
        }

        public void Update(Model model)
        {
            Model updateToModel = _models.SingleOrDefault(m => m.ModelId == model.ModelId);
            updateToModel.BrandId = model.BrandId;
            updateToModel.ModelName = model.ModelName;
        }
    }
}