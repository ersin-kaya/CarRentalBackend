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





        }

        private static void CarCrudTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Create
            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 11,
            //        ColorId = 4,
            //        DailyPrice = 1500,
            //        ModelYear = 2018,
            //        Description = "Ehliyet yasi 4 yil ve uzeri olmali."
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 12,
            //        ColorId = 1,
            //        DailyPrice = 1250,
            //        ModelYear = 2022,
            //        Description = "Ehliyet yasi 5 yil ve uzeri olmali."
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 14,
            //        ColorId = 1,
            //        DailyPrice = 1000,
            //        ModelYear = 2018,
            //        Description = "Ehliyet yasi 3 yil ve uzeri olmali."
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        BrandId = 15,
            //        ColorId = 1,
            //        DailyPrice = 800,
            //        ModelYear = 2019,
            //        Description = "Ehliyet yasi 2 yil ve uzeri olmali."
            //    });

            //Update
            //carManager.Update(
            //    new Car
            //    { 
            //        CarId=6, 
            //        BrandId=14, 
            //        ColorId=1, 
            //        ModelYear=2018, 
            //        DailyPrice=1100, 
            //        Description= "Ehliyet yasi 3 yil ve uzeri olmali." 
            //    });

            //Delete
            //carManager.Delete(new Car { CarId=7 });

            //Read
            //GetAll()
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " / " + car.DailyPrice);
            }

            //GetById
            Console.WriteLine("GetById(5).ModelYear > " + carManager.GetById(5).ModelYear);
        }

        private static void ColorCrudTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Create
            //colorManager.Add(new Color { ColorName = "Beyazz" });
            //colorManager.Add(new Color { ColorName = "Siyah" });
            //colorManager.Add(new Color { ColorName = "Kırmızı" });
            //colorManager.Add(new Color { ColorName = "Lacivert" });
            //colorManager.Add(new Color { ColorName = "Turuncu" });
            //colorManager.Add(new Color { ColorName = "Gri" });
            //colorManager.Add(new Color { ColorName = "Bordo" });
            //colorManager.Add(new Color { ColorName = "Yeşil" });
            //colorManager.Add(new Color { ColorName = "Açık Mavi" });
            //colorManager.Add(new Color { ColorName = "Koyu Gri" });

            //Update
            //colorManager.Update(new Color { ColorId = 1, ColorName = "Beyaz" });

            //Delete
            //colorManager.Delete(new Color { ColorId = 3 });

            //Read
            //GetAll()
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            //GetById
            Console.WriteLine("GetById(6) > " + colorManager.GetById(6).ColorName);
        }

        private static void BrandCrudTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Create
            //brandManager.Add(new Brand { BrandName = "Subaru" });
            //brandManager.Add(new Brand { BrandName = "Hyundai" });
            //brandManager.Add(new Brand { BrandName = "Audi" });
            //brandManager.Add(new Brand { BrandName = "Ford" });
            //brandManager.Add(new Brand { BrandName = "Renault" });
            //brandManager.Add(new Brand { BrandName = "Mazdaa" });

            //Update
            //brandManager.Update(new Brand { BrandId = 16, BrandName = "Mazda" });

            //Delete
            //brandManager.Delete(new Brand { BrandId = 13 });

            //Read
            //GetAll()
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            //GetById()
            Console.WriteLine("GetById(11) > " + brandManager.GetById(11).BrandName);
        }

        private static void CarBusinessTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { DailyPrice = 0, Description = "Ehliyet yasi 3 yil ve uzeri olmali." });
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car newCar = new Car { CarId = 7, BrandId = 5, ColorId = 2, DailyPrice = 600, ModelYear = 2018, Description = "Ehliyet yaşı 2 ve üzeri : Polo" };


            //GetAll
            InMemoryGetCars(carManager);

            //Add
            carManager.Add(newCar);
            Console.WriteLine("Added");

            InMemoryGetCars(carManager);

            //Update
            carManager.Update(new Car { CarId = 7, BrandId = 5, ColorId = 2, DailyPrice = 650, ModelYear = 2019, Description = "Ehliyet yaşı 3 ve üzeri : Polo" });
            Console.WriteLine("Updated");

            InMemoryGetCars(carManager);

            //Delete
            carManager.Delete(newCar);
            Console.WriteLine("Deleted");

            InMemoryGetCars(carManager);

            //GetById
            Console.WriteLine("GetById for Id=6");
            Console.WriteLine(carManager.GetById(6).Description);

            Console.ReadLine();
        }

        private static void InMemoryGetCars(CarManager carManager)
        {
            Console.WriteLine("GÜNCEL ARAÇ LİSTESİ----------------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
