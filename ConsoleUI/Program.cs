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

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { DailyPrice = 0, Description = "Ehliyet yasi 3 yil ve uzeri olmali." });

            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            //ColorManager colorManager = new ColorManager(new EfColorDal());

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
