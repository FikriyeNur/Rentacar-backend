using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             select new RentalDetailDto { Id = r.Id, CustomerId = cu.CustomerId, CompanyName = cu.CompanyName, NameSurname = u.FirstName + " " + u.LastName, CarId = c.CarId, BrandName = b.BrandName, ModelName = m.ModelName, DailyPrice = c.DailyPrice, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                if (filter == null)
                {
                    return result.ToList();
                }
                return result.Where(filter).ToList();
            }
        }

        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             select new RentalDetailDto { Id = r.Id, CustomerId = cu.CustomerId, CompanyName = cu.CompanyName, NameSurname=u.FirstName + " " +u.LastName, CarId = c.CarId, BrandName = b.BrandName, ModelName = m.ModelName, DailyPrice = c.DailyPrice, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.FirstOrDefault(r => r.Id == rentalId);
            }
        }

        public bool IsCarAvailable(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && r.ReturnDate == null
                             select r;
                return (result.Count() == 0) ? true : false;
            }
        }
    }
}
