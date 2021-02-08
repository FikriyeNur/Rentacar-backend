using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int carId);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByModelId(int modelId);
        List<CarDetailDto> GetAllCarDetails();
        CarDetailDto GetCarDetail(int carId);
        List<Car> GetEconomicCars();
        List<Car> GetComfortCars();
        List<Car> GetLuxuryCars();

    }
}
