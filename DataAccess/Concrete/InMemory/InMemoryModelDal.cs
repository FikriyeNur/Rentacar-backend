using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Model {ModelId=1, BrandId=1, ModelName="Clio", ModelYear="2018"},
                new Model {ModelId=2, BrandId=1, ModelName="Symbol", ModelYear="2015"},
                new Model {ModelId=3, BrandId=2, ModelName="Egea", ModelYear="2019"},
                new Model {ModelId=4, BrandId=2, ModelName="Panda", ModelYear="2017"},
                new Model {ModelId=5, BrandId=3, ModelName="Duster", ModelYear="2014"},
                new Model {ModelId=6, BrandId=3, ModelName="Sandero", ModelYear="2016"},
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

        public List<Model> GetAll()
        {
            return _models;
        }

        public List<Model> GetById(int Id)
        {
            return _models.Where(m => m.ModelId == Id).ToList();
        }

        public void Update(Model model)
        {
            Model updateToModel = _models.SingleOrDefault(m => m.ModelId == model.ModelId);
            updateToModel.BrandId = model.BrandId;
            updateToModel.ModelName = model.ModelName;
            updateToModel.ModelYear = model.ModelYear;
        }
    }
}