using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            #region InMemory

            //CarManager inMemoryCarManager = new CarManager(new InMemoryCarDal());
            //BrandManager inMemorybrandManager = new BrandManager(new InMemoryBrandDal());
            //ColorManager inMemorycolorManager = new ColorManager(new InMemoryColorDal());
            //ModelManager inMemorymodelManager = new ModelManager(new InMemoryModelDal());

            //GetCarList(inMemoryCarManager, inMemorybrandManager, inMemorymodelManager, inMemorycolorManager);
            //GetById(inMemoryCarManager, inMemorybrandManager, inMemorymodelManager, inMemorycolorManager);
            //CarAdd(inMemoryCarManager);
            //CarUpdate(inMemoryCarManager);
            //CarDelete(inMemoryCarManager);
          
            #endregion

            #region Entity Framework

            //CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //ModelManager modelManager = new ModelManager(new EfModelDal());

            //GetCarList(carManager, brandManager, modelManager, colorManager);
            //GetById(carManager, brandManager, modelManager, colorManager);
            //CarAdd(carManager);
            //CarUpdate(carManager);
            //CarDelete(carManager);
            //GetCarsByBrandId(carManager);
            //GetCarsByColorId(carManager);
            //GetCarsByModelId(carManager);

            //BrandAdd(brandManager);
            //BrandUpdate(brandManager);
            //BrandDelete(brandManager);
            //GetBrandList(brandManager);

            //GetColorList(colorManager);
            //ColorAdd(colorManager);
            //ColorUpdate(colorManager);
            //ColorDelete(colorManager);

            //GetModelList(modelManager);
            //ModelAdd(modelManager);
            //ModelUpdate(modelManager);
            //ModelDelete(modelManager); 
            #endregion

            Console.ReadLine();
        }

        private static void ModelDelete(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Kayıt Silme Ekranı ----------");
            Console.WriteLine("Model Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Model deletedModel = new Model { ModelId = id };

            if (id == deletedModel.ModelId)
            {
                Console.WriteLine("Model kaydını silmek üzeresiniz!! İşleme devam etmek için EVET yazınız.");
                string answer = Console.ReadLine();
                if (answer == "EVET".ToLower())
                {
                    modelManager.Delete(deletedModel);
                    Console.WriteLine("Marka kaydı başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Marka kaydı silme işlemi yapılmadı!!");
                }
            }
        }

        private static void ModelUpdate(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Bilgileri Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Model Id:");
            int modelId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marka Id:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Adı: ");
            string modelName = Console.ReadLine();

            Model updatedModel = new Model { ModelId = modelId, BrandId = brandId, ModelName = modelName };
            modelManager.Update(updatedModel);
            Console.WriteLine(" ");
            Console.WriteLine("Model güncelleme işlemi başarıyla gerçekleşti.");
        }

        private static void ModelAdd(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Ekleme Ekranı ----------");
            Console.WriteLine("Marka Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Adı: ");
            string modelName = Console.ReadLine();

            Model addedModel = new Model { BrandId = brandId, ModelName = modelName };
            modelManager.Add(addedModel);
            Console.WriteLine(" ");
            Console.WriteLine("Model kayıt işlemi başarıyla gerçekleşti.");
        }

        private static void GetModelList(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Listesi ----------");
            foreach (var model in modelManager.GetAll())
            {
                Console.WriteLine($"Model Id: {model.ModelId} -- {model.ModelName}");
            }
        }

        private static void ColorDelete(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Kayıt Silme Ekranı ----------");
            Console.WriteLine("Renk Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Color deletedColor = new Color { ColorId = id };

            if (id == deletedColor.ColorId)
            {
                Console.WriteLine("Renk kaydını silmek üzeresiniz!! İşleme devam etmek için EVET yazınız.");
                string answer = Console.ReadLine();
                if (answer == "EVET".ToLower())
                {
                    colorManager.Delete(deletedColor);
                    Console.WriteLine("Marka kaydı başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Marka kaydı silme işlemi yapılmadı!!");
                }
            }
        }

        private static void ColorUpdate(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Bilgileri Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Renk Id:");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Renk Adı: ");
            string colorName = Console.ReadLine();

            Color updatedColor = new Color { ColorId = colorId, ColorName = colorName };
            colorManager.Update(updatedColor);
            Console.WriteLine(" ");
            Console.WriteLine("Renk güncelleme işlemi başarıyla gerçekleşti.");
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Ekleme Ekranı ----------");
            Console.WriteLine("Renk Adı: ");
            string colorName = Console.ReadLine();

            Color addedColor = new Color { ColorName = colorName };
            colorManager.Add(addedColor);
            Console.WriteLine(" ");
            Console.WriteLine("Renk kayıt işlemi başarıyla gerçekleşti.");
        }

        private static void GetColorList(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Listesi ----------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"Renk Id: {color.ColorId} -- {color.ColorName}");
            }
        }

        private static void BrandDelete(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Kayıt Silme Ekranı ----------");
            Console.WriteLine("Marka Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Brand deletedBrand = new Brand { BrandId = id };

            if (id == deletedBrand.BrandId)
            {
                Console.WriteLine("Marka kaydını silmek üzeresiniz!! İşleme devam etmek için EVET yazınız.");
                string answer = Console.ReadLine();
                if (answer == "EVET".ToLower())
                {
                    brandManager.Delete(deletedBrand);
                    Console.WriteLine("Marka kaydı başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Marka kaydı silme işlemi yapılmadı!!");
                }
            }
        }

        private static void BrandUpdate(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Bilgileri Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Marka Id:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marka Adı: ");
            string brandName = Console.ReadLine();

            Brand updatedBrand = new Brand { BrandId = brandId, BrandName = brandName };
            brandManager.Update(updatedBrand);
            Console.WriteLine(" ");
            Console.WriteLine("Marka güncelleme işlemi başarıyla gerçekleşti.");
        }

        private static void BrandAdd(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Ekleme Ekranı ----------");
            Console.WriteLine("Marka Adı: ");
            string brandName = Console.ReadLine();

            Brand addedBrand = new Brand { BrandName = brandName };
            brandManager.Add(addedBrand);
            Console.WriteLine(" ");
            Console.WriteLine("Marka kayıt işlemi başarıyla gerçekleşti.");
        }

        private static void GetBrandList(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Listesi ----------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"Marka Id: {brand.BrandId} -- {brand.BrandName}");
            }
        }

        private static void GetCarsByModelId(CarManager carManager)
        {
            Console.WriteLine("---------- Arabaları Modele Göre Filtreleme ----------");
            Console.WriteLine("Model Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (var byModelId in carManager.GetCarsByModelId(id))
            {
                Console.WriteLine($"{byModelId.CarId} - {byModelId.DailyPrice} - {byModelId.Description}");
            }


        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("---------- Arabaları Renge Göre Filtreleme ----------");
            Console.WriteLine("Renk Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (var byColorId in carManager.GetCarsByColorId(id))
            {
                Console.WriteLine($"{byColorId.CarId} - {byColorId.DailyPrice} - {byColorId.Description}");
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("---------- Arabaları Markaya Göre Filtreleme ----------");
            Console.WriteLine("Marka Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (var byBrandId in carManager.GetCarsByBrandId(id))
            {
                Console.WriteLine($"{byBrandId.CarId} - {byBrandId.DailyPrice} - {byBrandId.Description}");
            }
        }

        private static void CarDelete(CarManager carManager)
        {
            Console.WriteLine("---------- Araba Kayıt Silme Ekranı ----------");
            Console.WriteLine("Araba Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Car deletedCar = new Car { CarId = id };

            if (id == deletedCar.CarId)
            {
                Console.WriteLine("Araba kaydını silmek üzeresiniz!! İşleme devam etmek için EVET yazınız.");
                string answer = Console.ReadLine();
                if (answer == "EVET".ToLower())
                {
                    carManager.Delete(deletedCar);
                    Console.WriteLine("Araba kaydı başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Araba kaydı silme işlemi yapılmadı!!");
                }
            }
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("---------- Araba Kayıt Güncelleme Ekranı ----------");
            Console.WriteLine("Araba Id: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marka Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Id: ");
            int modelId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Renk Id: ");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Yılı: ");
            string modelYear = Console.ReadLine();
            Console.WriteLine("Günlük Ücret: ");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Açıklama: ");
            string description = Console.ReadLine();

            Car updatedCar = new Car { CarId = carId, BrandId = brandId, ColorId = colorId, ModelId = modelId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };
            carManager.Update(updatedCar);
            Console.WriteLine(" ");
            Console.WriteLine("Araba güncelleme işlemi başarıyla gerçekleşti.");
        }

        private static void CarAdd(CarManager carManager)
        {
            Console.WriteLine("---------- Araba Kayıt Ekranı ----------");
            // Id bilgisi veri tabanından otomatik atanıyor.
            Console.WriteLine("Marka Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Id: ");
            int modelId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Renk Id: ");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Yılı: ");
            string modelYear = Console.ReadLine();
            Console.WriteLine("Günlük Ücret: ");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Açıklama: ");
            string description = Console.ReadLine();

            Car addedCar = new Car { BrandId = brandId, ColorId = colorId, ModelId = modelId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };
            carManager.Add(addedCar);
            Console.WriteLine(" ");
            Console.WriteLine("Araba kayıt işlemi başarıyla gerçekleşti.");     
        }

        private static void GetById(CarManager carManager, BrandManager brandManager, ModelManager modelManager, ColorManager colorManager)
        {
            Console.WriteLine("---------- Araba Detay Ekranı ----------");
            Console.WriteLine("Araba Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll()
                         on c.BrandId equals b.BrandId
                         join m in modelManager.GetAll()
                         on c.ModelId equals m.ModelId
                         join co in colorManager.GetAll()
                         on c.ColorId equals co.ColorId
                         where c.CarId == id
                         select new CarDto { BrandName = b.BrandName, CarId = c.CarId, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, ColorName = co.ColorName, ModelName = m.ModelName };

            if (result.Any(c => c.CarId == id))
            {
                foreach (var carDto in result)
                {
                    Console.WriteLine("Araba Id: {0} \nMarka: {1} \nModel: {2} \nModel Yılı: {3} \nRenk: {4} \nGünlük Fiyat: {5} \nAçıklama: {6}", carDto.CarId, carDto.BrandName, carDto.ModelName, carDto.ModelYear, carDto.ColorName, carDto.DailyPrice, carDto.Description);
                }
            }
            else
            {
                Console.WriteLine("Giridiğiniz Id'ye ait kayıt bulunmamıştır! Lütfen geçerli ID giriniz.");
            }

            Console.ReadLine();
        }

        private static void GetCarList(CarManager carManager, BrandManager brandManager, ModelManager modelManager, ColorManager colorManager)
        {
            Console.WriteLine("---------- Araba Liste Ekranı ----------");

            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll()
                         on c.BrandId equals b.BrandId
                         join m in modelManager.GetAll()
                         on c.ModelId equals m.ModelId
                         join co in colorManager.GetAll()
                         on c.ColorId equals co.ColorId
                         orderby c.DailyPrice descending
                         select new CarDto { BrandName = b.BrandName, CarId = c.CarId, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, ColorName = co.ColorName, ModelName = m.ModelName };

            foreach (var carDto in result)
            {
                Console.WriteLine("Araba Id: {0} \nMarka: {1} \nModel: {2} \nModel Yılı: {3} \nRenk: {4} \nGünlük Fiyat: {5} \nAçıklama: {6}", carDto.CarId, carDto.BrandName, carDto.ModelName, carDto.ModelYear, carDto.ColorName, carDto.DailyPrice, carDto.Description);
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
