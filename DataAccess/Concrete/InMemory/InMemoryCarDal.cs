using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2021, DailyPrice=400, Description="Ehliyet yaşı 1 ve üzeri : Clio"},
                new Car{CarId=2, BrandId=2, ColorId=1, ModelYear=2021, DailyPrice=450, Description="Ehliyet yaşı 1 ve üzeri : Egea"},
                new Car{CarId=3, BrandId=3, ColorId=1, ModelYear=2021, DailyPrice=650, Description="Ehliyet yaşı 2 ve üzeri : Corsa"},
                new Car{CarId=4, BrandId=1, ColorId=3, ModelYear=2022, DailyPrice=900, Description="Ehliyet yaşı 4 ve üzeri : Talisman"},
                new Car{CarId=5, BrandId=1, ColorId=1, ModelYear=2021, DailyPrice=700, Description="Ehliyet yaşı 3 ve üzeri : Megane"},
                new Car{CarId=6, BrandId=4, ColorId=5, ModelYear=2019, DailyPrice=750, Description="Ehliyet yaşı 3 ve üzeri : Elantra"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
