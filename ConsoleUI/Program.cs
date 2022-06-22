using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();
            //CarBusinessTest();

            //9. Gün - Ödev 1 Başlangıcı
            //BrandCrudTest();
            //ColorCrudTest();
            //CarCrudTest();
            //CarDtoTest();

            //10. Gün - Ödev 4 Başlangıcı
            //AddUser();
            //AddCustomer();
        }

        private static void AddCustomer()
        {
            //Customer
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //customerManager.Add(new Customer { CompanyName = "Kodlama.io", UserId = 1 });
            //customerManager.Add(new Customer { CompanyName = "Microsoft", UserId = 5 });
            //customerManager.Add(new Customer { CompanyName = "BTK", UserId = 6 });
        }

        private static void AddUser()
        {
            //User
            UserManager userManager = new UserManager(new EfUserDal());

            //userManager.Add(new User { FirstName="Engin", LastName="Demiroğ", Email="abcd.email@gmail.com", Password="abcd1234" });
            //userManager.Add(new User { FirstName="Ersin", LastName="Kaya", Email="ersin-kaya@outlook.com.tr", Password="abcd1234" });
            //userManager.Add(new User { FirstName="Furkan", LastName="Yıldırım", Email="abcd_email@outlook.com", Password="abcd1234" });
            //userManager.Add(new User { FirstName="Serkan", LastName="Kılıç", Email="abcd-email@outlook.com", Password="abcd1234" });
            //userManager.Add(new User { FirstName="Hakan", LastName="Şen", Email="abcd-email@outlook.com.tr", Password="abcd1234" });
        }

        private static void CarDtoTest()
        {
            CarManager carManagerToDto = new CarManager(new EfCarDal());

            foreach (var car in carManagerToDto.GetCarDetails().Data)
            {
                Console.WriteLine
                    (
                    "-Brand : " + car.BrandName + "\n" +
                    " -> Daily price : " + car.DailyPrice + "\n" +
                    " -> Color : " + car.ColorName + "\n" +
                    " -> Description : " + car.Description + "\n"
                    );
            }
        }

        private static void CarCrudTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Create
            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 7,
            //        ColorId = 4,
            //        DailyPrice = 1500,
            //        ModelYear = 2018,
            //        Description = "Ehliyet yasi 4 yil ve uzeri olmali."
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 1,
            //        ColorId = 1,
            //        DailyPrice = 1250,
            //        ModelYear = 2022,
            //        Description = "Ehliyet yasi 5 yil ve uzeri olmali."
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 4,
            //        ColorId = 1,
            //        DailyPrice = 1000,
            //        ModelYear = 2018,
            //        Description = "Ehliyet yasi 3 yil ve uzeri olmali."
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 2,
            //        ColorId = 1,
            //        DailyPrice = 800,
            //        ModelYear = 2019,
            //        Description = "Ehliyet yasi 2 yil ve uzeri olmali."
            //    });

            //Update
            //carManager.Update(
            //    new Car
            //    {
            //        Id = 2,
            //        BrandId = 7,
            //        ColorId = 1,
            //        ModelYear = 2023,
            //        DailyPrice = 1750,
            //        Description = "Ehliyet yasi 5 yil ve uzeri olmali."
            //    });

            //Delete
            //carManager.Delete(new Car { Id = 5 });

            //Read
            //GetAll()
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " / " + car.DailyPrice);
                }

                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            //GetById
            Console.WriteLine("GetById(2).ModelYear > " + carManager.GetById(2).Data.ModelYear);

        }

        private static void ColorCrudTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Create
            //colorManager.Add(new Color { Name = "Beyazz" });
            //colorManager.Add(new Color { Name = "Siyah" });
            //colorManager.Add(new Color { Name = "Kırmızı" });
            //colorManager.Add(new Color { Name = "Lacivert" });
            //colorManager.Add(new Color { Name = "Turuncu" });
            //colorManager.Add(new Color { Name = "Gri" });
            //colorManager.Add(new Color { Name = "Bordo" });
            //colorManager.Add(new Color { Name = "Yeşil" });
            //colorManager.Add(new Color { Name = "Açık Mavi" });
            //colorManager.Add(new Color { Name = "Koyu Gri" });
            //colorManager.Add(new Color { Name = "Açık Gri" });

            //Update
            //colorManager.Update(new Color { Id = 1, Name = "Beyaz" });
            //colorManager.Update(new Color { Id = 11, Name = "Açık Gri 2" });

            //Delete
            //colorManager.Delete(new Color { Id = 3 });
            //colorManager.Delete(new Color { Id = 11 });

            //Read
            //GetAll()
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }

            //GetById
            Console.WriteLine("GetById(6) > " + colorManager.GetById(6).Data.Name);
        }

        private static void BrandCrudTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Create
            //brandManager.Add(new Brand { Name = "Subaru" });
            //brandManager.Add(new Brand { Name = "Hyundai" });
            //brandManager.Add(new Brand { Name = "Audi" });
            //brandManager.Add(new Brand { Name = "Ford" });
            //brandManager.Add(new Brand { Name = "Renault" });
            //brandManager.Add(new Brand { Name = "Mazdaa" });
            //brandManager.Add(new Brand { Name = "TOGG" });
            //brandManager.Add(new Brand { Name = "Ferrarii" });

            //Update
            //brandManager.Update(new Brand { Id = 6, Name = "Mazda" });
            //brandManager.Update(new Brand { Id = 8, Name = "Ferrari" });

            //Delete
            //brandManager.Delete(new Brand { Id = 5 });
            //brandManager.Delete(new Brand { Id = 6 });

            //Read
            //GetAll()
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }

            //GetById()
            Console.WriteLine("GetById(7) > " + brandManager.GetById(7).Data.Name);
        }

        private static void CarBusinessTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { DailyPrice = 0, Description = "Ehliyet yasi 3 yil ve uzeri olmali." });
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car newCar = new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 600, ModelYear = 2018, Description = "Ehliyet yaşı 2 ve üzeri : Polo" };


            //GetAll
            InMemoryGetCars(carManager);

            //Add
            carManager.Add(newCar);
            Console.WriteLine("Added");

            InMemoryGetCars(carManager);

            //Update
            carManager.Update(new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 650, ModelYear = 2019, Description = "Ehliyet yaşı 3 ve üzeri : Polo" });
            Console.WriteLine("Updated");

            InMemoryGetCars(carManager);

            //Delete
            carManager.Delete(newCar);
            Console.WriteLine("Deleted");

            InMemoryGetCars(carManager);

            //GetById
            Console.WriteLine("GetById for Id=6");
            Console.WriteLine(carManager.GetById(6).Data.Description);

            Console.ReadLine();
        }

        private static void InMemoryGetCars(CarManager carManager)
        {
            Console.WriteLine("GÜNCEL ARAÇ LİSTESİ----------------------------------");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
