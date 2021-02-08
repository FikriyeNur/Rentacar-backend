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

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ModelManager modelManager = new ModelManager(new EfModelDal());


            // Entity Framework Car - Brand - Model - Color Bilgileri

            //GetCarFilter(carManager);

            //GetCarInformation(carManager);

            //GetBrandInformation(brandManager);

            //GetModelInformation(modelManager);

            //GetColorInformation(colorManager);

            Console.ReadLine();
        }

        private static void GetColorInformation(ColorManager colorManager)
        {
            Console.WriteLine("----- Renk İşlemleri -----");
            Console.WriteLine("1.Renk Listesi");
            Console.WriteLine("2.Renk Detayı");
            Console.WriteLine("3.Yeni Renk Ekleme");
            Console.WriteLine("4.Renk Bilgileri Güncelleme");
            Console.WriteLine("5.Renk Verileri Silme");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetColorList(colorManager);
                    break;
                case 2:
                    GetColorById(colorManager);
                    break;
                case 3:
                    ColorAdd(colorManager);
                    break;
                case 4:
                    ColorUpdate(colorManager);
                    break;
                case 5:
                    ColorDelete(colorManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void GetModelInformation(ModelManager modelManager)
        {
            Console.WriteLine("----- Model İşlemleri -----");
            Console.WriteLine("1.Model Listesi");
            Console.WriteLine("2.Model Detayları");
            Console.WriteLine("3.Yeni Model Ekleme");
            Console.WriteLine("4.Model Bilgileri Güncelleme");
            Console.WriteLine("5.Model Verileri Silme");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetAllModelDetailsDto(modelManager);
                    break;
                case 2:
                    GetModelById(modelManager);
                    break;
                case 3:
                    ModelAdd(modelManager);
                    break;
                case 4:
                    ModelUpdate(modelManager);
                    break;
                case 5:
                    ModelDelete(modelManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void GetBrandInformation(BrandManager brandManager)
        {
            Console.WriteLine("----- Marka İşlemleri -----");
            Console.WriteLine("1.Marka Listesi");
            Console.WriteLine("2.Marka Detayı");
            Console.WriteLine("3.Yeni Marka Ekleme");
            Console.WriteLine("4.Marka Bilgileri Güncelleme");
            Console.WriteLine("5.Marka Verileri Silme");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetBrandList(brandManager);
                    break;
                case 2:
                    GetBrandById(brandManager);
                    break;
                case 3:
                    BrandAdd(brandManager);
                    break;
                case 4:
                    BrandUpdate(brandManager);
                    break;
                case 5:
                    BrandDelete(brandManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void GetCarInformation(CarManager carManager)
        {
            Console.WriteLine("----- FNH Araç Kiralama Sistemi -----");
            Console.WriteLine("1.Araba Listesi");
            Console.WriteLine("2.Araç Detayları");
            Console.WriteLine("3.Yeni Araç Ekleme");
            Console.WriteLine("4.Araç Bilgileri Güncelleme");
            Console.WriteLine("5.Araç Verileri Silme");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetAllCarDetailsDto(carManager);
                    break;
                case 2:
                    GetCarDetailDto(carManager);
                    break;
                case 3:
                    CarAdd(carManager);
                    break;
                case 4:
                    CarUpdate(carManager);
                    break;
                case 5:
                    CarDelete(carManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void GetCarFilter(CarManager carManager)
        {
            Console.WriteLine("Araba filtereleme seçenekleri: ");
            Console.WriteLine("1.Markaya Göre");
            Console.WriteLine("2.Renge Göre");
            Console.WriteLine("3.Modele Göre");
            Console.WriteLine("4.Ekonomik Sınıf Arabalar");
            Console.WriteLine("5.Konfor Sınıf Arabalar");
            Console.WriteLine("6.Lüks Sınıf Arabalar");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz filtremele işleminin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetCarsByBrandId(carManager);
                    break;
                case 2:
                    GetCarsByColorId(carManager);
                    break;
                case 3:
                    GetCarsByModelId(carManager);
                    break;
                case 4:
                    GetEconomicCars(carManager);
                    break;
                case 5:
                    GetComfortCars(carManager);
                    break;
                case 6:
                    GetLuxuryCars(carManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void GetLuxuryCars(CarManager carManager)
        {
            Console.WriteLine("---------- Lüks Sınıf Araçlar ----------");
            Console.WriteLine($"Araç sayısı: {carManager.GetLuxuryCars().Count()}");
            Console.WriteLine(" ");
            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetLuxuryCars())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetComfortCars(CarManager carManager)
        {
            Console.WriteLine("---------- Konfor Sınıf Araçlar ----------");
            Console.WriteLine($"Araç sayısı: {carManager.GetComfortCars().Count()}");
            Console.WriteLine(" ");
            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetComfortCars())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetEconomicCars(CarManager carManager)
        {
            Console.WriteLine("---------- Ekonomik Sınıf Araçlar ----------");
            Console.WriteLine($"Araç sayısı: {carManager.GetEconomicCars().Count()}");
            Console.WriteLine(" ");
            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetEconomicCars())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetCarDetailDto(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Detay Ekranı ----------");
            Console.WriteLine("Araba Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            Console.WriteLine("Car Id\tBrand Name\tModel Name\tModel Year\tColor Name\tDaily Price\tDescriptions");

            var result = carManager.GetCarDetail(id);
            Console.WriteLine($"{result.CarId}\t{result.BrandName}\t\t{result.ModelName}\t\t{result.ModelYear}\t\t{result.ColorName}\t\t{result.DailyPrice}\t{result.Description}");
        }

        private static void GetAllCarDetailsDto(CarManager carManager)
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

        private static void GetAllModelDetailsDto(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Listesi ----------");
            Console.WriteLine($"Model sayısı: {modelManager.GetAllModelDetails().Count()}");
            Console.WriteLine(" ");

            Console.WriteLine("Model Id\tBrand Name\t\tModel Name");
            foreach (var model in modelManager.GetAllModelDetails())
            {
                Console.WriteLine($"{model.ModelId}\t\t{model.BrandName}\t\t\t{model.ModelName}");
            }
        }

        private static void GetModelList(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Listesi ----------");
            Console.WriteLine($"Model sayısı: {modelManager.GetAll().Count()}");
            Console.WriteLine(" ");

            Console.WriteLine("Model Id\tBrand Id\tModel Name");
            foreach (var model in modelManager.GetAll())
            {
                Console.WriteLine($"{model.ModelId}\t\t{model.BrandId}\t\t{model.ModelName}");
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
            Console.WriteLine($"Renk sayısı: {colorManager.GetAll().Count()}");
            Console.WriteLine(" ");

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
            Console.WriteLine($"Marka sayısı: {brandManager.GetAll().Count()}");
            Console.WriteLine(" ");

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
            Console.WriteLine($"Araç sayısı: {carManager.GetAll().Count()}");
            Console.WriteLine(" ");

            Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
            }
        }

    }
}