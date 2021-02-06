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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                if (entity.CarId > 0)
                {
                    Console.WriteLine("Araba kayıt işlemi başarıyla gerçekleşti.");
                }
                else
                {
                    Console.WriteLine("Araba kayıt işlemi yapılamadı!!");
                }
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                if (entity.CarId > 0)
                {
                    Console.WriteLine("Araba silme işlemi başarıyla gerçekleşti.");
                }
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().FirstOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ModelName = m.ModelName, ModelYear = c.ModelYear, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ModelName = m.ModelName, ModelYear = c.ModelYear, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description };

                return result.FirstOrDefault(c => c.CarId == carId);
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                if (entity.CarId > 0)
                {
                    Console.WriteLine("Araba güncelleme işlemi başarıyla gerçekleşti.");
                }
            }
        }
    }
}
