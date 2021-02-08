using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EfEntityRepositoryBase<Model, RentACarContext>, IModelDal
    {
        public List<ModelDetailDto> GetAllModelDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from m in context.Models
                             join b in context.Brands
                             on m.BrandId equals b.BrandId
                             select new ModelDetailDto { ModelId = m.ModelId, BrandName = b.BrandName, ModelName = m.ModelName };
                return result.ToList();
            }
        }
    }
}
