using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2021, DailyPrice=400, Description="Ehliyet yaşı 1 ve üzeri : Clio"},
                new Car{Id=2, BrandId=2, ColorId=1, ModelYear=2021, DailyPrice=450, Description="Ehliyet yaşı 1 ve üzeri : Egea"},
                new Car{Id=3, BrandId=1, ColorId=1, ModelYear=2021, DailyPrice=650, Description="Ehliyet yaşı 2 ve üzeri : Corsa"},
                new Car{Id=4, BrandId=3, ColorId=3, ModelYear=2022, DailyPrice=900, Description="Ehliyet yaşı 4 ve üzeri : Talisman"},
                new Car{Id=5, BrandId=3, ColorId=1, ModelYear=2020, DailyPrice=700, Description="Ehliyet yaşı 2 ve üzeri : Megane"},
                new Car{Id=6, BrandId=4, ColorId=5, ModelYear=2019, DailyPrice=750, Description="Ehliyet yaşı 3 ve üzeri : Elantra"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
