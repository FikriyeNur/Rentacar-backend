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
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<CarDetailDto> GetCarDetail(int carId);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByModelId(int modelId);
        IDataResult<List<CarDetailDto>> GetEconomicCars();
        IDataResult<List<CarDetailDto>> GetComfortCars();
        IDataResult<List<CarDetailDto>> GetLuxuryCars();

        IResult TransactionalOperation(Car car);

    }
}
