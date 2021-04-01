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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ModelId = m.ModelId,
                                 ModelName = m.ModelName,
                                 ModelYear = c.ModelYear,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = (from ci in context.CarImages where (ci.CarId == c.CarId) select ci).FirstOrDefault().ImagePath
                             };
                if (filter == null)
                {
                    return result.ToList();
                }
                return result.Where(filter).ToList();
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
                             select new CarDetailDto { CarId = c.CarId, BrandId = b.BrandId, BrandName = b.BrandName, ModelId = m.ModelId, ModelName = m.ModelName, ModelYear = c.ModelYear, ColorId = co.ColorId, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description };

                return result.FirstOrDefault(c => c.CarId == carId);
            }
        }
    }
}
