using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Geçersiz fiyat bilgisi girdiniz!! Günlük araba ücreti 0'dan büyük olmalı.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            return _carDal.GetAllCarDetails();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public CarDetailDto GetCarDetail(int carId)
        {
            return _carDal.GetCarDetail(carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetCarsByModelId(int modelId)
        {
            return _carDal.GetAll(c => c.ModelId == modelId);
        }

        public List<Car> GetComfortCars()
        {
            return _carDal.GetAll(c => c.Description.Contains("Kon"));
        }

        public List<Car> GetEconomicCars()
        {
            return _carDal.GetAll(c => c.Description.Contains("Eko"));
        }

        public List<Car> GetLuxuryCars()
        {
            return _carDal.GetAll(c => c.Description.Contains("Lüks"));
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Geçersiz fiyat bilgisi girdiniz!! Günlük araba ücreti 0'dan büyük olmalı.");
            }
        }
    }
}
