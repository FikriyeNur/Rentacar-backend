using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByModelId(int modelId);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<CarDetailDto> GetCarDetail(int carId);
        IDataResult<List<Car>> GetEconomicCars();
        IDataResult<List<Car>> GetComfortCars();
        IDataResult<List<Car>> GetLuxuryCars();

        IResult TransactionalOperation(Car car);

    }
}
