using Business.Concrete;
using Core.Utilities.Results.Abstract;
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

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            #region EntityFramework Car - Brand - Model - Color - User - Customer - Rental Bilgileri

            Console.WriteLine("*-*-* FNH Araç Kiralama Sitemi *-*-*");
            Console.WriteLine("1.Araç Kiralama");
            Console.WriteLine("2.Müşteri Araç Bilgileri");
            Console.WriteLine("3.Müşteri Bilgileri");
            Console.WriteLine("4.Firma Araç İşlemleri");

            int result = Convert.ToInt32(Console.ReadLine());
            switch (result)
            {
                case 1:
                    RentalPanel(rentalManager);
                    break;
                case 2:
                    CustomerInformationPanel(carManager, brandManager, modelManager);
                    break;
                case 3:
                    RentalInformationPanel(userManager, customerManager, rentalManager);
                    break;
                case 4:
                    UserPanel(carManager, brandManager, modelManager, colorManager, userManager, customerManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }

            #endregion



            Console.ReadLine();
        }

        private static void RentalPanel(RentalManager rentalManager)
        {
            Console.WriteLine("----- FNH Araç Kiralama Sitesine Hoş Geldiniz -----");
            Console.WriteLine("1.Araç Kiralama");
            Console.WriteLine("2.Araç Kiralama Bilgilerini Güncelleme");
            Console.WriteLine("3.Araç Kiralama İptali");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    RentalAdd(rentalManager);
                    break;
                case 2:
                    RentalUpdate(rentalManager);
                    break;
                case 3:
                    RentalDelete(rentalManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void RentalInformationPanel(UserManager userManager, CustomerManager customerManager, RentalManager rentalManager)
        {
            Console.WriteLine("----- FNH Araç Kiralama Sitesine Hoş Geldiniz -----");
            Console.WriteLine("1.Müşteri Araç Kiralama Bilgileri");
            Console.WriteLine("2.Müşteri Bilgileri");
            Console.WriteLine("3.Kullanıcı Bilgileri");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetAllRentalDetailsDto(rentalManager);
                    break;
                case 2:
                    GetCustomerDetailsDto(customerManager);
                    break;
                case 3:
                    GetUserList(userManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void UserPanel(CarManager carManager, BrandManager brandManager, ModelManager modelManager, ColorManager colorManager, UserManager userManager, CustomerManager customerManager)
        {
            Console.WriteLine("----- FNH Araç Kiralama Sistemi -----");
            Console.WriteLine("1.Yeni Araç Ekleme");
            Console.WriteLine("2.Araç Bilgilerini Güncelleme");
            Console.WriteLine("3.Araç Kaydını Silme");
            Console.WriteLine("4.Yeni Marka Ekleme");
            Console.WriteLine("5.Marka Bilgilerini Güncelleme");
            Console.WriteLine("6.Marka Kaydını Silme");
            Console.WriteLine("7.Yeni Model Ekleme");
            Console.WriteLine("8.Model Bilgilerini Güncelleme");
            Console.WriteLine("9.Model Kaydını Silme");
            Console.WriteLine("10.Renk Listesi");
            Console.WriteLine("11.Yeni Renk Ekleme");
            Console.WriteLine("12.Renk Bilgilerini Güncelleme");
            Console.WriteLine("13.Renk Kaydını Silme");
            Console.WriteLine("14.Yeni Kullanıcı Ekleme");
            Console.WriteLine("15.Kullanıcı Bilgilerini Güncelleme");
            Console.WriteLine("16.Kullanıcı Kaydını Silme");
            Console.WriteLine("17.Yeni Müşteri Ekleme ");
            Console.WriteLine("18.Müşteri Bilgilerini Güncelleme");
            Console.WriteLine("19.Müşteri Kaydını Silme");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    CarAdd(carManager);
                    break;
                case 2:
                    CarUpdate(carManager);
                    break;
                case 3:
                    CarDelete(carManager);
                    break;
                case 4:
                    BrandAdd(brandManager);
                    break;
                case 5:
                    BrandUpdate(brandManager);
                    break;
                case 6:
                    BrandDelete(brandManager);
                    break;
                case 7:
                    ModelAdd(modelManager);
                    break;
                case 8:
                    ModelUpdate(modelManager);
                    break;
                case 9:
                    ModelDelete(modelManager);
                    break;
                case 10:
                    GetColorList(colorManager);
                    break;
                case 11:
                    ColorAdd(colorManager);
                    break;
                case 12:
                    ColorUpdate(colorManager);
                    break;
                case 13:
                    ColorDelete(colorManager);
                    break;
                case 14:
                    UserAdd(userManager);
                    break;
                case 15:
                    UserUpdate(userManager);
                    break;
                case 16:
                    UserDelete(userManager);
                    break;
                case 17:
                    CustomerAdd(customerManager);
                    break;
                case 18:
                    CustomerUpdate(customerManager);
                    break;
                case 19:
                    CustomerDelete(customerManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void CustomerInformationPanel(CarManager carManager, BrandManager brandManager, ModelManager modelManager)
        {
            Console.WriteLine("----- FNH Araç Kiralama Sitesine Hoş Geldiniz -----");
            Console.WriteLine("1.Araç Bilgileri");
            Console.WriteLine("2.Araç Filtreleme Seçenekleri");
            Console.WriteLine(" ");
            Console.WriteLine("Seçmek istediğiniz işlemin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    CustomerPanel(carManager, brandManager, modelManager);
                    break;
                case 2:
                    CustomerCarFilterPanel(carManager, brandManager, modelManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void CustomerPanel(CarManager carManager, BrandManager brandManager, ModelManager modelManager)
        {
            Console.WriteLine("1.Araba Listesi");
            Console.WriteLine("2.Araç Detayları");
            Console.WriteLine("3.Marka Listesi");
            Console.WriteLine("4.Model Listesi");
            Console.WriteLine(" ");
            Console.WriteLine("5.Üst Menüye Dön");

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
                    GetBrandList(brandManager);
                    break;
                case 4:
                    GetAllModelDetailsDto(modelManager);
                    break;
                case 5:
                    CustomerInformationPanel(carManager, brandManager, modelManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private static void CustomerCarFilterPanel(CarManager carManager, BrandManager brandManager, ModelManager modelManager)
        {
            Console.WriteLine("******** Araç Filtreleme Seçenekleri ********");
            Console.WriteLine("1.Markaya Göre");
            Console.WriteLine("2.Modele Göre");
            Console.WriteLine("3.Renkelerine Göre");
            Console.WriteLine(" ");
            Console.WriteLine("***** Araç Ücretlerine Göre Filtreleme Seçenekleri *****");
            Console.WriteLine("4.Ekonomik Sınıf Arabalar");
            Console.WriteLine("5.Konfor Sınıf Arabalar");
            Console.WriteLine("6.Lüks Sınıf Arabalar");
            Console.WriteLine(" ");
            Console.WriteLine("7. Üst Menüye Dön");
            Console.WriteLine("Seçmek istediğiniz filtremele işleminin numarasını giriniz: ");

            int result = Convert.ToInt32(Console.ReadLine());

            switch (result)
            {
                case 1:
                    GetCarsByBrandId(carManager);
                    break;
                case 2:
                    GetCarsByModelId(carManager);
                    break;
                case 3:
                    GetCarsByColorId(carManager);
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
                case 7:
                    CustomerInformationPanel(carManager, brandManager, modelManager);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız!! Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        #region Rental CRUD Operasyonları

        private static void RentalDelete(RentalManager rentalManager)
        {
            Console.WriteLine("---------- Araç Kiralama İptal Ekranı ----------");
            Console.WriteLine("Araç Kiralama Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Rental deleteRental = new Rental { Id = id };

            var result = rentalManager.Delete(deleteRental);
            SuccessRental(result);
        }

        private static void RentalUpdate(RentalManager rentalManager)
        {
            Console.WriteLine("---------- Araç Kiralama Bilgilerini Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int carId, customerId;
            string rentDate, returnDate;
            RentalColons(out carId, out customerId, out rentDate, out returnDate);

            DateTime? returnDateConvert = null;
            if (returnDate != "")
            {
                returnDateConvert = Convert.ToDateTime(returnDate);
            }
            else
            {
                returnDateConvert = null;
            }

            Rental addRental = new Rental { Id = id, CarId = carId, CustomerId = customerId, RentDate = Convert.ToDateTime(rentDate), ReturnDate = returnDateConvert };

            var result = rentalManager.Uptade(addRental);
            SuccessRental(result);
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            Console.WriteLine("---------- Araç Kiralama Ekranı ----------");
            int carId, customerId;
            string rentDate, returnDate;
            RentalColons(out carId, out customerId, out rentDate, out returnDate);

            DateTime? returnDateConvert = null;
            if (returnDate != "")
            {
                returnDateConvert = Convert.ToDateTime(returnDate);
            }
            else
            {
                returnDateConvert = null;
            }

            Rental addRental = new Rental { CarId = carId, CustomerId = customerId, RentDate = Convert.ToDateTime(rentDate), ReturnDate = returnDateConvert };
            var result = rentalManager.Add(addRental);
            SuccessRental(result);
        }

        private static void GetAllRentalDetailsDto(RentalManager rentalManager)
        {
            Console.WriteLine("---------- Araç Kiralama Listesi ----------");

            var result = rentalManager.GetAllRentalDetails();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Kiralanan Araç sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                foreach (var rental in result.Data)
                {
                    Console.WriteLine($"Id: {rental.Id}\nMüşteri Id: {rental.CustomerId}\nŞirket Adı: {rental.CompanyName}\nKullanıcı Adı: {rental.UserFirstName}\nKullanıcı Soyadı: {rental.UserLastName}\nAraba Id:{rental.CarId}\nMarka Adı: {rental.BrandName}\nModel Adı: {rental.ModelName}\nKiralama Tarihi: {rental.RentDate}\nİade Tarihi: {rental.ReturnDate}");
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region Customer CRUD Operasyonları

        private static void CustomerDelete(CustomerManager customerManager)
        {
            Console.WriteLine("---------- Müşteri Kayıt Silme Ekranı ----------");
            Console.WriteLine("Müşteri Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Customer deleteCustomer = new Customer { CustomerId = id };

            var result = customerManager.Delete(deleteCustomer);
            SuccessCustomer(customerManager, result);
        }

        private static void CustomerUpdate(CustomerManager customerManager)
        {
            Console.WriteLine("---------- Müşteri Bilgilerini Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Müşteri Id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kullanıcı Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Şirket Adı: ");
            string companyName = Console.ReadLine();

            Customer addCustomer = new Customer { CustomerId = customerId, UserId = userId, CompanyName = companyName };

            var result = customerManager.Uptade(addCustomer);
            SuccessCustomer(customerManager, result);
        }

        private static void CustomerAdd(CustomerManager customerManager)
        {
            Console.WriteLine("---------- Müşteri Ekleme Ekranı ----------");
            Console.WriteLine("Kullanıcı Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Şirket Adı: ");
            string companyName = Console.ReadLine();

            Customer addCustomer = new Customer { UserId = userId, CompanyName = companyName };

            var result = customerManager.Add(addCustomer);
            SuccessCustomer(customerManager, result);
        }

        private static void GetCustomerById(CustomerManager customerManager)
        {
            Console.WriteLine("---------- Müşteri Bilgileri Detay Ekranı ----------");
            Console.WriteLine("Müşteri Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = customerManager.GetById(id);
            if (result.Data != null)
            {
                Console.WriteLine("Customer Id\tUser Id\t\tCompany Name");
                Console.WriteLine($"{result.Data.CustomerId}\t\t{result.Data.UserId}\t\t{result.Data.CompanyName}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("---------- Müşteri Listesi ----------");

            var result = customerManager.GetAll();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Müşteri sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");

                Console.WriteLine("Customer Id\tUser Id\tCompany Name");
                foreach (var customer in result.Data)
                {
                    Console.WriteLine($"{customer.CustomerId}\t\t{customer.UserId}\t\t{customer.CompanyName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCustomerDetailsDto(CustomerManager customerManager)
        {
            Console.WriteLine("---------- Müşteri Listesi ----------");

            var result = customerManager.GetAllCustomerDetails();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Müşteri sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");

                foreach (var customer in result.Data)
                {
                    Console.WriteLine($"Customer Id: {customer.CustomerId}\nCompany Name: {customer.CompanyName}\nFirst Name: {customer.UserFirstName}\nLast Name: {customer.UserLastName}\nE-Mail: {customer.EMail}");
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region User CRUD Operasyonları

        private static void UserDelete(UserManager userManager)
        {
            Console.WriteLine("---------- Kullanıcı Kaydı Silme Ekranı ----------");
            Console.WriteLine("Kullanıcı Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            User deleteUser = new User { UserId = id };

            var result = userManager.Delete(deleteUser);
            SuccessUser(userManager, result);
        }

        private static void UserUpdate(UserManager userManager)
        {
            Console.WriteLine("---------- Kullanıcı Bilgileri Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Kullanıcı Id:");
            int userId = Convert.ToInt32(Console.ReadLine());
            string firstName, lastName, eMail, password;
            UserColons(out firstName, out lastName, out eMail, out password);

            User updateUser = new User { UserId = userId, FirstName = firstName, LastName = lastName, EMail = eMail, Password = password };

            var result = userManager.Uptade(updateUser);
            SuccessUser(userManager, result);
        }

        private static void UserAdd(UserManager userManager)
        {
            Console.WriteLine("---------- Kullanıcı Ekleme Ekranı ----------");
            string firstName, lastName, eMail, password;
            UserColons(out firstName, out lastName, out eMail, out password);

            User addUser = new User { FirstName = firstName, LastName = lastName, EMail = eMail, Password = password };

            var result = userManager.Add(addUser);
            SuccessUser(userManager, result);
        }

        private static void GetUserById(UserManager userManager)
        {
            Console.WriteLine("---------- Kullanıcı Detay Ekranı ----------");
            Console.WriteLine("Kullanıcı Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = userManager.GetById(id);
            if (result.Data != null)
            {
                Console.WriteLine("User Id\t\tFirst Name\tLast Name\tEMail\t\t\tPassword");
                Console.WriteLine($"{result.Data.UserId}\t\t{result.Data.FirstName}\t\t{result.Data.LastName}\t\t{result.Data.EMail}\t{result.Data.Password}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetUserList(UserManager userManager)
        {
            Console.WriteLine("---------- Kullanıcı Listesi ----------");

            var result = userManager.GetAll();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Kullanıcı sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");

                Console.WriteLine("User Id\t\tFirst Name\t\tLast Name\t\tEMail");
                foreach (var user in result.Data)
                {
                    Console.WriteLine($"{user.UserId}\t\t{user.FirstName}\t\t\t{user.LastName}\t\t\t{user.EMail}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region Model CRUD Operasyonları

        private static void ModelDelete(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Kayıt Silme Ekranı ----------");
            Console.WriteLine("Model Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Model deleteModel = new Model { ModelId = id };

            var result = modelManager.Delete(deleteModel); ;
            SuccessModel(modelManager, result);
        }

        private static void ModelUpdate(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Bilgilerini Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Model Id:");
            int modelId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marka Id:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Adı: ");
            string modelName = Console.ReadLine();

            Model updateModel = new Model { ModelId = modelId, BrandId = brandId, ModelName = modelName };

            var result = modelManager.Update(updateModel);
            SuccessModel(modelManager, result);
        }

        private static void ModelAdd(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Kayıt Ekleme Ekranı ----------");
            Console.WriteLine("Marka Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Adı: ");
            string modelName = Console.ReadLine();

            Model addModel = new Model { BrandId = brandId, ModelName = modelName };

            var result = modelManager.Add(addModel);
            SuccessModel(modelManager, result);
        }

        private static void GetModelById(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Bilgileri Detay Ekranı ----------");
            Console.WriteLine("Model Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = modelManager.GetById(id);
            if (result.Data != null)
            {
                Console.WriteLine("Model Id\tBrand Id\tModel Name");
                Console.WriteLine($"{result.Data.ModelId}\t\t{result.Data.BrandId}\t\t{result.Data.ModelName}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllModelDetailsDto(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Listesi ----------");

            var result = modelManager.GetAllModelDetails();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Model sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                Console.WriteLine("Model Id\tBrand Name\t\tModel Name");
                foreach (var model in result.Data)
                {
                    Console.WriteLine($"{model.ModelId}\t\t{model.BrandName}\t\t\t{model.ModelName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetModelList(ModelManager modelManager)
        {
            Console.WriteLine("---------- Model Listesi ----------");

            var result = modelManager.GetAll();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Model sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                Console.WriteLine("Model Id\tBrand Id\tModel Name");
                foreach (var model in result.Data)
                {
                    Console.WriteLine($"{model.ModelId}\t\t{model.BrandId}\t\t{model.ModelName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region Color CRUD Operasyonları

        private static void ColorDelete(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Kayıt Silme Ekranı ----------");
            Console.WriteLine("Renk Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Color deleteColor = new Color { ColorId = id };

            var result = colorManager.Delete(deleteColor);
            SuccessColor(colorManager, result);
        }

        private static void ColorUpdate(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Bilgilerini Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Renk Id:");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Renk Adı: ");
            string colorName = Console.ReadLine();

            Color updateColor = new Color { ColorId = colorId, ColorName = colorName };

            var result = colorManager.Update(updateColor);
            SuccessColor(colorManager, result);
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Kayıt Ekleme Ekranı ----------");
            Console.WriteLine("Renk Adı: ");
            string colorName = Console.ReadLine();

            Color addColor = new Color { ColorName = colorName };

            var result = colorManager.Add(addColor);
            SuccessColor(colorManager, result);
        }

        private static void GetColorById(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Bilgileri Detay Ekranı ----------");
            Console.WriteLine("Renk Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = colorManager.GetById(id);
            if (result.Data != null)
            {
                Console.WriteLine("Color Id\tColor Name");
                Console.WriteLine($"{result.Data.ColorId}\t\t{result.Data.ColorName}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetColorList(ColorManager colorManager)
        {
            Console.WriteLine("---------- Renk Listesi ----------");

            var result = colorManager.GetAll();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Renk sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");

                Console.WriteLine("Color Id\tColor Name");
                foreach (var color in result.Data)
                {
                    Console.WriteLine($"{color.ColorId}\t\t{color.ColorName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region Brand CRUD Operasyonları

        private static void BrandDelete(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Kayıt Silme Ekranı ----------");
            Console.WriteLine("Marka Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Brand deleteBrand = new Brand { BrandId = id };

            var result = brandManager.Delete(deleteBrand);
            SuccessBrand(brandManager, result);
        }

        private static void BrandUpdate(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Bilgilerini Güncelleme Ekleme Ekranı ----------");
            Console.WriteLine("Marka Id:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marka Adı: ");
            string brandName = Console.ReadLine();

            Brand updateBrand = new Brand { BrandId = brandId, BrandName = brandName };

            var result = brandManager.Update(updateBrand);
            SuccessBrand(brandManager, result);
        }

        private static void BrandAdd(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Kayıt Ekleme Ekranı ----------");
            Console.WriteLine("Marka Adı: ");
            string brandName = Console.ReadLine();

            Brand addBrand = new Brand { BrandName = brandName };

            var result = brandManager.Add(addBrand);
            SuccessBrand(brandManager, result);
        }

        private static void GetBrandById(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Bilgileri Detay Ekranı ----------");
            Console.WriteLine("Marka Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = brandManager.GetById(id);
            if (result.Data != null)
            {
                Console.WriteLine("Brand Id\tBrand Name");
                Console.WriteLine($"{result.Data.BrandId}\t\t{result.Data.BrandName}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetBrandList(BrandManager brandManager)
        {
            Console.WriteLine("---------- Marka Listesi ----------");

            var result = brandManager.GetAll();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Marka sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");

                Console.WriteLine("Brand Id\tBrand Name");
                foreach (var brand in result.Data)
                {
                    Console.WriteLine($"{brand.BrandId}\t\t{brand.BrandName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region Car Filter

        private static void GetLuxuryCars(CarManager carManager)
        {
            Console.WriteLine("---------- Lüks Sınıf Araçlar ----------");

            var result = carManager.GetLuxuryCars();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Araç sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                Console.WriteLine("Car Id\t\tModel Year\tDaily Price\tDescriptions");
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.CarId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t{car.Description}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetComfortCars(CarManager carManager)
        {
            Console.WriteLine("---------- Konfor Sınıf Araçlar ----------");

            var result = carManager.GetComfortCars();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Araç sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                Console.WriteLine("Car Id\t\tModel Year\tDaily Price\tDescriptions");
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.CarId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t{car.Description}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetEconomicCars(CarManager carManager)
        {
            Console.WriteLine("---------- Ekonomik Sınıf Araçlar ----------");

            var result = carManager.GetEconomicCars();
            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Araç sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                Console.WriteLine("Car Id\t\tModel Year\tDaily Price\tDescriptions");
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.CarId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t{car.Description}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarDetailDto(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Bilgileri Detay Ekranı ----------");
            Console.WriteLine("Araba Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = carManager.GetCarDetail(id);
            if (result.Data != null)
            {
                Console.WriteLine("Car Id\tBrand Name\tModel Name\tModel Year\tColor Name\tDaily Price\tDescriptions");
                Console.WriteLine($"{result.Data.CarId}\t{result.Data.BrandName}\t\t{result.Data.ModelName}\t\t{result.Data.ModelYear}\t\t{result.Data.ColorName}\t\t{result.Data.DailyPrice}\t{result.Data.Description}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllCarDetailsDto(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Liste Ekranı ----------");

            var result = carManager.GetAllCarDetails();

            if (result.Data.Count() > 0)
            {
                Console.WriteLine($"Araç sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");
                Console.WriteLine("Car Id\tBrand Name\tModel Name\tDaily Price");
                foreach (var carDto in result.Data)
                {
                    Console.WriteLine($"{carDto.CarId}\t{carDto.BrandName}\t\t{carDto.ModelName}\t\t{carDto.DailyPrice}");
                }
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void GetCarsByModelId(CarManager carManager)
        {
            Console.WriteLine("---------- Araçları Modele Göre Filtreleme ----------");
            Console.WriteLine("Model Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var result = carManager.GetCarsByModelId(id);

            if (result.Data.Count() > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{result.Data.Count()} adet araç bulundu.");
                Console.WriteLine(" ");

                Console.WriteLine("Car Id\tModel Year\tDaily Price\tDescriptions");
                foreach (var byModelId in result.Data)
                {
                    Console.WriteLine($"{byModelId.CarId}\t{byModelId.ModelYear}\t\t{byModelId.DailyPrice}\t{byModelId.Description}");
                }
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("---------- Araçları Renge Göre Filtreleme ----------");
            Console.WriteLine("Renk Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var result = carManager.GetCarsByColorId(id);

            if (result.Data.Count() > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{result.Data.Count()} adet araç bulundu.");
                Console.WriteLine(" ");
                Console.WriteLine("Car Id\tModel Year\tDaily Price\tDescriptions");
                foreach (var byColorId in result.Data)
                {
                    Console.WriteLine($"{byColorId.CarId}\t{byColorId.ModelYear}\t\t{byColorId.DailyPrice}\t{byColorId.Description}");
                }
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("---------- Araçları Markaya Göre Filtreleme ----------");
            Console.WriteLine("Marka Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var result = carManager.GetCarsByBrandId(id);

            if (result.Data.Count() > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{result.Data.Count()} adet araç bulundu.");
                Console.WriteLine(" ");
                Console.WriteLine("Car Id\tModel Year\tDaily Price\tDescriptions");
                foreach (var byBrandId in result.Data)
                {
                    Console.WriteLine($"{byBrandId.CarId}\t{byBrandId.ModelYear}\t\t{byBrandId.DailyPrice}\t{byBrandId.Description}");
                }
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        #endregion

        #region Car CRUD Operasyonları

        private static void CarDelete(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Kayıt Silme Ekranı ----------");
            Console.WriteLine("Araba Id:");
            int id = Convert.ToInt32(Console.ReadLine());

            var deleteCar = carManager.GetById(id).Data;
            var result = carManager.Delete(deleteCar);

            SuccessCar(carManager, result);
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Kayıt Güncelleme Ekranı ----------");
            Console.WriteLine("Araba Id: ");
            int carId = Convert.ToInt32(Console.ReadLine());

            int brandId, modelId, colorId;
            string modelYear, description;
            decimal dailyPrice;
            CarColons(out brandId, out modelId, out colorId, out modelYear, out dailyPrice, out description);

            Car updateCar = new Car { CarId = carId, BrandId = brandId, ModelId = modelId, ColorId = colorId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };

            var result = carManager.Update(updateCar);
            SuccessCar(carManager, result);
        }

        private static void CarAdd(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Kayıt Ekranı ----------");
            // Id bilgisi veri tabanından otomatik atanıyor.

            int brandId, modelId, colorId;
            string modelYear, description;
            decimal dailyPrice;
            CarColons(out brandId, out modelId, out colorId, out modelYear, out dailyPrice, out description);

            Car addCar = new Car { BrandId = brandId, ColorId = colorId, ModelId = modelId, ModelYear = modelYear, DailyPrice = dailyPrice, Description = description };

            var result = carManager.Add(addCar);
            SuccessCar(carManager, result);
        }

        private static void GetCarById(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Bilgileri Detay Ekranı ----------");
            Console.WriteLine("Araba Id'si giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            var result = carManager.GetById(id);
            if (result.Data != null)
            {
                Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
                Console.WriteLine($"{result.Data.CarId}\t{result.Data.BrandId}\t\t{result.Data.ModelId}\t\t{result.Data.ModelYear}\t\t{result.Data.ColorId}\t\t{result.Data.DailyPrice}\t{result.Data.Description}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarList(CarManager carManager)
        {
            Console.WriteLine("---------- Araç Liste Ekranı ----------");

            var result = carManager.GetAll();
            if (result.Data != null)
            {
                Console.WriteLine($"Araç sayısı: {result.Data.Count()}");
                Console.WriteLine(" ");

                Console.WriteLine("Car Id\tBrand Id\tModel Id\tModel Year\tColor Id\tDaily Price\tDescriptions");
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ModelId}\t\t{car.ModelYear}\t\t{car.ColorId}\t\t{car.DailyPrice}\t{car.Description}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion 

        #region Success
        private static void SuccessRental(IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void SuccessCustomer(CustomerManager customerManager, IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
                Console.WriteLine(" ");
                GetCustomerList(customerManager);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void SuccessUser(UserManager userManager, IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
                Console.WriteLine(" ");
                GetUserList(userManager);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void SuccessModel(ModelManager modelManager, IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
                Console.WriteLine(" ");
                GetModelList(modelManager);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void SuccessColor(ColorManager colorManager, IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
                Console.WriteLine(" ");
                GetColorList(colorManager);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void SuccessBrand(BrandManager brandManager, IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
                Console.WriteLine(" ");
                GetBrandList(brandManager);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        private static void SuccessCar(CarManager carManager, IResult result)
        {
            if (result.Success)
            {
                Console.WriteLine("\n" + result.Message);
                Console.WriteLine(" ");
                GetCarList(carManager);
            }
            else
            {
                Console.WriteLine("\n" + result.Message);
            }
        }

        #endregion

        #region Colons

        private static void RentalColons(out int carId, out int customerId, out string rentDate, out string returnDate)
        {
            Console.WriteLine("Araba Id: ");
            carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Müşteri Id: ");
            customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kiralama Tarihi: ");
            rentDate = Console.ReadLine();
            Console.WriteLine("İade Tarihi: ");
            returnDate = Console.ReadLine();
        }

        private static void UserColons(out string firstName, out string lastName, out string eMail, out string password)
        {
            Console.WriteLine("Kullanıcı Adı: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Kullanıcı Soyadı: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            eMail = Console.ReadLine();
            Console.WriteLine("Şifre: ");
            password = Console.ReadLine();
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

        #endregion
    }
}