﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal carDal = new InMemoryCarDal();
            CarManager carManager = new CarManager(carDal);

            IBrandDal brandDal = new InMemoryBrandDal();
            BrandManager brandManager = new BrandManager(brandDal);

            IModelDal modelDal = new InMemoryModelDal();
            ModelManager modelManager = new ModelManager(modelDal);

            IColorDal colorDal = new InMemoryColorDal();
            ColorManager colorManager = new ColorManager(colorDal);

            GetCarList(carManager, brandManager, modelManager, colorManager);
            Console.WriteLine(" ");
            GetById(carManager, brandManager, modelManager, colorManager);
            Console.WriteLine(" ");

        }

        private static void GetById(CarManager carManager, BrandManager brandManager, ModelManager modelManager, ColorManager colorManager)
        {
            Console.WriteLine("Araba Id'si giriniz: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll()
                         on c.BrandId equals b.BrandId
                         join m in modelManager.GetAll()
                         on c.ModelId equals m.ModelId
                         join co in colorManager.GetAll()
                         on c.ColorId equals co.ColorId
                         where c.CarId == Id
                         select new CarDto { BrandName = b.BrandName, CarId = c.CarId, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = m.ModelYear, ColorName = co.ColorName, ModelName = m.ModelName };

            foreach (var carDto in result)
            {
                Console.WriteLine("Marka: {0} \nModel: {1} \nModel Yılı: {2} \nRenk: {3} \nGünlük Fiyat: {4} \nAçıklama: {5}", carDto.BrandName, carDto.ModelName, carDto.ModelYear, carDto.ColorName, carDto.DailyPrice, carDto.Description);
            }

            Car car1 = new Car { CarId = 7, BrandId = 3, ColorId = 4, DailyPrice = 215, ModelId = 6, ModelYear = "2018", Description = "Otomatik vites - Dizel" };
            carManager.Add(car1);
         
            Console.ReadLine();
        }

        private static void GetCarList(CarManager carManager, BrandManager brandManager, ModelManager modelManager, ColorManager colorManager)
        {
            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll()
                         on c.BrandId equals b.BrandId
                         join m in modelManager.GetAll()
                         on c.ModelId equals m.ModelId
                         join co in colorManager.GetAll()
                         on c.ColorId equals co.ColorId
                         orderby c.DailyPrice
                         select new CarDto { BrandName = b.BrandName, CarId = c.CarId, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = m.ModelYear, ColorName = co.ColorName, ModelName = m.ModelName };
            

            foreach (var carDto in result)
            {
                Console.WriteLine("Marka: {0} \nModel: {1} \nModel Yılı: {2} \nRenk: {3} \nGünlük Fiyat: {4} \nAçıklama: {5}", carDto.BrandName, carDto.ModelName, carDto.ModelYear, carDto.ColorName, carDto.DailyPrice, carDto.Description);
                Console.WriteLine("--------------------------------");
            }
        }

        public class CarDto
        {
            public int CarId { get; set; }
            public string BrandName { get; set; }
            public string ColorName { get; set; }
            public string ModelName { get; set; }
            public string ModelYear { get; set; }
            public decimal DailyPrice { get; set; }
            public string Description { get; set; }
        }
    }
}
