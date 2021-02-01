using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{

    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId=1, BrandId=1, ColorId=1, ModelId=1, DailyPrice=210, Description="Otomatik Vites - Dizel"},
                new Car {CarId=2, BrandId=2, ColorId=2, ModelId=2, DailyPrice=209, Description="Düz Vites - Benzin"},
                new Car {CarId=3, BrandId=3, ColorId=2, ModelId=3, DailyPrice=245, Description="Düz Vites - Benzin"},
                new Car {CarId=4, BrandId=1, ColorId=1, ModelId=4, DailyPrice=265, Description="Otomatik Dizel"},
                new Car {CarId=5, BrandId=2, ColorId=3, ModelId=5, DailyPrice=265, Description="Düz Vites - Dizel"},
                new Car {CarId=6, BrandId=3, ColorId=4, ModelId=6, DailyPrice=251, Description="Düz Vites- Benzin"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
           return _cars.FirstOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
