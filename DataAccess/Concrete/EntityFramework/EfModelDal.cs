using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : IModelDal
    {
        public void Add(Model entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                if (entity.ModelId > 0)
                {
                    Console.WriteLine("Model kayıt işlemi başarıyla gerçekleşti.");
                }
                else
                {
                    Console.WriteLine("Model kayıt işlemi yapılamadı!!");
                }
            }
        }

        public void Delete(Model entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

                if (entity.ModelId > 0)
                {
                    Console.WriteLine("Model silme işlemi başarıyla gerçekleşti.");
                }
            }
        }

        public Model Get(Expression<Func<Model, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Model>().FirstOrDefault(filter);
            }
        }

        public List<Model> GetAll(Expression<Func<Model, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Model>().ToList()
                    : context.Set<Model>().Where(filter).ToList();
            }
        }

        public void Update(Model entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                if (entity.ModelId > 0)
                {
                    Console.WriteLine("Moded güncelleme işlemi başarıyla gerçekleşti.");
                }
            }
        }
    }
}
