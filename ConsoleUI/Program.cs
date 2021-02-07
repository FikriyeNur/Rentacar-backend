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

            //CarGetList(inMemoryCarManager);
            //CarGetById(inMemoryCarManager); // kodları düzelt ÇALIŞMIYOR

            #endregion

            #region Entity Framework

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ModelManager modelManager = new ModelManager(new EfModelDal());

            #region  Car
            //GetCarList(carManager);
            //GetCarById(carManager);
            //GetCarList(carManager, brandManager, modelManager, colorManager);
            //GetById(carManager, brandManager, modelManager, colorManager);
            //CarAdd(carManager);
            //CarUpdate(carManager);
            //CarDelete(carManager);         
            #endregion

            #region Brand
            //GetBrandList(brandManager);
            GetBrandById(brandManager);
            //BrandAdd(brandManager);
            //BrandUpdate(brandManager);
            //BrandDelete(brandManager); 
            #endregion

            #region Color
            //GetColorList(colorManager);
            GetColorById(colorManager);
            //ColorAdd(colorManager);
            //ColorUpdate(colorManager);
            //ColorDelete(colorManager); 
            #endregion

            #region Model
            //GetModelList(modelManager);
            GetModelById(modelManager);
            //ModelAdd(modelManager);
            //ModelUpdate(modelManager);
            //ModelDelete(modelManager);  
            #endregion

            #region DTO Car Details
            //GetAllCarDetailsDTO(carManager);
            //GetCarDetailDTO(carManager); 
            #endregion

            #region Car Filter
            //GetCarsByBrandId(carManager);
            //GetCarsByColorId(carManager);
            //GetCarsByModelId(carManager); 
            //GetEconomicCars(carManager);
            //GetConfortCars(carManager);
            //GetLuxuryCars(carManager); 
            #endregion

            #endregion

            Console.ReadLine();
        }

        private static void GetLuxuryCars(CarManager carManager)
        {
            Console.WriteLine("---------- Lüks Sınıf Araçlar ----------");
            Console.WriteLine(" ");
            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetLuxuryCars())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetConfortCars(CarManager carManager)
        {
            Console.WriteLine("---------- Konfor Sınıf Araçlar ----------");
            Console.WriteLine(" ");
            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetConfortCars())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetEconomicCars(CarManager carManager)
        {
            Console.WriteLine("---------- Ekonomik Sınıf Araçlar ----------");
            Console.WriteLine(" ");
            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetEconomicCars())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetCarDetailDTO(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Detay Ekranı ----------");
            Console.WriteLine("Araba Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            Console.WriteLine("Car Id\tBrand Name\tModel Name\tModel Year\tColor Name\tDaily Price\tDescriptions");

            var result = carManager.GetCarDetail(id);
            Console.WriteLine($"{result.CarId}\t{result.BrandName}\t\t{result.ModelName}\t\t{result.ModelYear}\t\t{result.ColorName}\t\t{result.DailyPrice}\t{result.Description}");
        }

        private static void GetAllCarDetailsDTO(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Liste Ekranı ----------");
            Console.WriteLine($"Araç sayısı: {carManager.GetAllCarDetails().Count()}");
            Console.WriteLine(" ");

            Console.WriteLine("Car Id\tBrand Name\tModel Name\tModel Year\tColor Name\tDaily Price\tDescriptions");
            foreach (var carDto in carManager.GetAllCarDetails())
            {
                Console.WriteLine($"{carDto.CarId}\t{carDto.BrandName}\t\t{carDto.ModelName}\t\t{carDto.ModelYear}\t\t{carDto.ColorName}\t\t{carDto.DailyPrice}\t{carDto.Description}");
            }
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
                }
                else
                {
                    Console.WriteLine("Marka kaydı silme işlemi yapılmadı!!");
                }
            }

            Console.WriteLine(" ");
            GetModelList(modelManager);
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
            GetModelList(modelManager);
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
            GetModelList(modelManager);
        }

        private static void GetModelById(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Detay Ekranı ----------");
            Console.WriteLine("Model Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            var result = modelManager.GetById(id);

            Console.WriteLine("Model Id\tBrand Id\tModel Name");
            Console.WriteLine($"{result.ModelId}\t\t{result.BrandId}\t\t{result.ModelName}");
        }

        private static void GetModelList(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Listesi ----------");
            Console.WriteLine("Model Id\tBrand Id\tModel Name");
            foreach (var model in modelManager.GetAll())
            {
                Console.WriteLine($"{model.ModelId}\t\t{model.BrandId}\tt\t{model.ModelName}");
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
                }
                else
                {
                    Console.WriteLine("Renk kaydı silme işlemi yapılmadı!!");
                }
            }

            Console.WriteLine(" ");
            GetColorList(colorManager);
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
            GetColorList(colorManager);
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Ekleme Ekranı ----------");
            Console.WriteLine("Renk Adı: ");
            string colorName = Console.ReadLine();

            Color addedColor = new Color { ColorName = colorName };
            colorManager.Add(addedColor);

            Console.WriteLine(" ");
            GetColorList(colorManager);
        }

        private static void GetColorById(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Detay Ekranı ----------");
            Console.WriteLine("Renk Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            var result = colorManager.GetById(id);

            Console.WriteLine("Color Id\tColor Name");
            Console.WriteLine($"{result.ColorId}\t\t{result.ColorName}");
        }

        private static void GetColorList(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Listesi ----------");
            Console.WriteLine("Color Id\tColor Name");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId}\t\t{color.ColorName}");
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
                }
                else
                {
                    Console.WriteLine("Marka kaydı silme işlemi yapılmadı!!");
                }
            }

            Console.WriteLine(" ");
            GetBrandList(brandManager);
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
            GetBrandList(brandManager);
        }

        private static void BrandAdd(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Ekleme Ekranı ----------");
            Console.WriteLine("Marka Adı: ");
            string brandName = Console.ReadLine();

            Brand addedBrand = new Brand { BrandName = brandName };
            brandManager.Add(addedBrand);

            Console.WriteLine(" ");
            GetBrandList(brandManager);
        }

        private static void GetBrandById(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Detay Ekranı ----------");
            Console.WriteLine("Marka Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            var result = brandManager.GetById(id);

            Console.WriteLine("Brand Id\tBrand Name");
            Console.WriteLine($"{result.BrandId}\t\t{result.BrandName}");
        }

        private static void GetBrandList(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Listesi ----------");
            Console.WriteLine("Brand Id\tBrand Name");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId}\t\t{brand.BrandName}");
            }
        }

        private static void GetCarsByModelId(CarManager carManager)
        {
            Console.WriteLine("---------- Araçları Modele Göre Filtreleme ----------");
            Console.WriteLine("Model Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (carManager.GetCarsByModelId(id).Count() > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{carManager.GetCarsByModelId(id).Count()} adet araç bulundu.");
                Console.WriteLine(" ");

                Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
                foreach (var byModelId in carManager.GetCarsByModelId(id))
                {
                    Console.WriteLine($"{byModelId.CarId}\t{byModelId.BrandId}\t\t{byModelId.ModelId}\t\t{byModelId.ModelYear}\t\t{byModelId.ColorId}\t\t{byModelId.DailyPrice}\t{byModelId.Description}");
                }
            }
            else
            {
                Console.WriteLine("Girdiğiniz Id'ye ait araç bulunamadı!!");
            }
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("---------- Araçları Renge Göre Filtreleme ----------");
            Console.WriteLine("Renk Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (carManager.GetCarsByColorId(id).Count() > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{carManager.GetCarsByColorId(id).Count()} adet araç bulundu.");
                Console.WriteLine(" ");

                Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
                foreach (var byColorId in carManager.GetCarsByColorId(id))
                {
                    Console.WriteLine($"{byColorId.CarId}\t{byColorId.BrandId}\t\t{byColorId.ModelId}\t\t{byColorId.ModelYear}\t\t{byColorId.ColorId}\t\t{byColorId.DailyPrice}\t{byColorId.Description}");
                }
            }
            else
            {
                Console.WriteLine("Girdiğiniz Id'ye ait araç bulunamadı!!");
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("---------- Araçları Markaya Göre Filtreleme ----------");
            Console.WriteLine("Marka Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (carManager.GetCarsByBrandId(id).Count() > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{carManager.GetCarsByBrandId(id).Count()} adet araç bulundu.");
                Console.WriteLine(" ");

                Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
                foreach (var byBrandId in carManager.GetCarsByBrandId(id))
                {
                    Console.WriteLine($"{byBrandId.CarId}\t{byBrandId.BrandId}\t\t{byBrandId.ModelId}\t\t{byBrandId.ModelYear}\t\t{byBrandId.ColorId}\t\t{byBrandId.DailyPrice}\t{byBrandId.Description}");
                }
            }
            else
            {
                Console.WriteLine("Girdiğiniz Id'ye ait araç bulunamadı!!");
            }
            Console.WriteLine(" ");

        }

        private static void CarDelete(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Kayıt Silme Ekranı ----------");
            Console.WriteLine("Araba Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var deletedCar = carManager.GetById(id);

            if (id == deletedCar.CarId)
            {
                Console.WriteLine("Araba kaydını silmek üzeresiniz!! İşleme devam etmek için EVET yazınız.");
                string answer = Console.ReadLine();
                if (answer == "EVET".ToLower())
                {
                    carManager.Delete(deletedCar);
                }
                else
                {
                    Console.WriteLine("Araba kaydı silme işlemi yapılmadı!!");
                }
            }

            Console.WriteLine(" ");
            GetCarList(carManager);
        }

        private static void CarUpdate(CarManager carManager)
        {
            GetCarById(carManager);
            Console.WriteLine(" ");

            Console.WriteLine("---------- Araç Kayıt Güncelleme Ekranı ----------");
            Console.WriteLine("Araba Id: ");
            int carId = Convert.ToInt32(Console.ReadLine());

            int brandId, modelId, colorId;
            string modelYear, description;
            decimal dailyPrice;
            CarColons(out brandId, out modelId, out colorId, out modelYear, out dailyPrice, out description);

            Car updatedCar = new Car { CarId = carId, BrandId = brandId, ModelId = modelId, ColorId = colorId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };
            carManager.Update(updatedCar);

            Console.WriteLine(" ");
            GetCarList(carManager);
        }

        private static void CarAdd(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Kayıt Ekranı ----------");
            // Id bilgisi veri tabanından otomatik atanıyor.

            int brandId, modelId, colorId;
            string modelYear, description;
            decimal dailyPrice;
            CarColons(out brandId, out modelId, out colorId, out modelYear, out dailyPrice, out description);

            Car addedCar = new Car { BrandId = brandId, ColorId = colorId, ModelId = modelId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };
            carManager.Add(addedCar);

            Console.WriteLine(" ");
            GetCarList(carManager);
        }

        private static void CarColons(out int brandId, out int modelId, out int colorId, out string modelYear, out decimal dailyPrice, out string description)
        {
            Console.WriteLine("Brand Id: ");
            brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Id: ");
            modelId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Color Id: ");
            colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Year: ");
            modelYear = Console.ReadLine();
            Console.WriteLine("Daily Price: ");
            dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Description: ");
            description = Console.ReadLine();
        }

        private static void GetCarById(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Detay Ekranı ----------");
            Console.WriteLine("Araba Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            var result = carManager.GetById(id);

            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            Console.WriteLine($"{result.CarId}\t{result.BrandId}\t\t{result.ModelId}\t\t{result.ModelYear}\t\t{result.ColorId}\t\t{result.DailyPrice}\t{result.Description}");
        }

        private static void GetCarList(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Liste Ekranı ----------");

            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

    }
}