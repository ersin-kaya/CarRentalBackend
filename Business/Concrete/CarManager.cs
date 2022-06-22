using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //constructor injection
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if ((car.Description.Length >= 2) && (car.DailyPrice > 0))  //araç ekleme işlemi belirtilen kurallara göre düzenlendi.
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarValueInvalid);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //business codes
            if (DateTime.Now.Hour == 23)    //örn. sistem saat 23'de bir saat boyunca bakımda
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);    //sadece mesaj döndürüyoruz. data döndürmeyeceğiz, bunun default'u null'dır. Araç listesi null dönecek. Araç listesi döndürme gereği duyuyoruz çünkü frontend'ci bunu ona göre karşılayacak, yani buradan bir liste geldiğini bilecek ve kodlarını o listeye göre yazacak ama data olmayacak.
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == carId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<int> GetModelYearForOldestCar()
        {
            var result = _carDal.GetAll().OrderBy(c=>c.ModelYear).First();

            return new SuccessDataResult<int>(result.ModelYear);
        }
    }
}
