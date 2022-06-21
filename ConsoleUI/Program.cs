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

            CarCrudTest();

            //CarDtoTest();
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
            //        CarId = 8,
            //        BrandId = 14,
            //        ColorId = 1,
            //        ModelYear = 2019,
            //        DailyPrice = 750,
            //        Description = "Ehliyet yasi 1 yil ve uzeri olmali."
            //    });

            //Delete
            //carManager.Delete(new Car { CarId=8 });

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
            Console.WriteLine("GetById(5).ModelYear > " + carManager.GetById(5).Data.ModelYear);

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
            //colorManager.Add(new Color { ColorName = "Açık Gri" });

            //Update
            //colorManager.Update(new Color { ColorId = 1, ColorName = "Beyaz" });
            //colorManager.Update(new Color { ColorId = 11, ColorName = "Açık Gri 2" });

            //Delete
            //colorManager.Delete(new Color { ColorId = 3 });
            //colorManager.Delete(new Color { ColorId = 11 });

            //Read
            //GetAll()
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            //GetById
            Console.WriteLine("GetById(6) > " + colorManager.GetById(6).Data.ColorName);
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
            //brandManager.Add(new Brand { BrandName = "TOGG" });
            //brandManager.Add(new Brand { BrandName = "Ferrarii" });

            //Update
            //brandManager.Update(new Brand { BrandId = 16, BrandName = "Mazda" });
            //brandManager.Update(new Brand { BrandId = 18, BrandName = "Ferrari" });

            //Delete
            //brandManager.Delete(new Brand { BrandId = 13 });
            //brandManager.Delete(new Brand { BrandId = 15 });

            //Read
            //GetAll()
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            //GetById()
            Console.WriteLine("GetById(17) > " + brandManager.GetById(17).Data.BrandName);
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
