using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car newCar = new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 600, ModelYear = 2018, Description = "Ehliyet yaşı 2 ve üzeri : Polo" };


            //GetAll
            GetCars(carManager);

            Console.ReadKey();
            Console.Clear();

            //Add
            carManager.Add(newCar);
            Console.WriteLine("Added");

            GetCars(carManager);

            Console.ReadKey();
            Console.Clear();

            //Update
            carManager.Update(new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 650, ModelYear = 2019, Description = "Ehliyet yaşı 3 ve üzeri : Polo" });
            Console.WriteLine("Updated");

            GetCars(carManager);

            Console.ReadKey();
            Console.Clear();

            //Delete
            carManager.Delete(newCar);
            Console.WriteLine("Deleted");

            GetCars(carManager);

            Console.ReadKey();
            Console.Clear();

            //GetById
            Console.WriteLine("GetById for Id=6");
            Console.WriteLine(carManager.GetById(6).Description);

            Console.ReadLine();
        }

        static void GetCars(CarManager carManager)
        {
            Console.WriteLine("GÜNCEL ARAÇ LİSTESİ----------------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
