using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("car.add,car,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.delete,car,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("car.get,car,admin")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //business codes
            if (DateTime.Now.Hour == 23)    //örn. sistem saat 23'de bir saat boyunca bakımda
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);    //sadece mesaj döndürüyoruz. data döndürmeyeceğiz, bunun default'u null'dır. Araç listesi null dönecek. Araç listesi döndürme gereği duyuyoruz çünkü frontend'ci bunu ona göre karşılayacak, yani buradan bir liste geldiğini bilecek ve kodlarını o listeye göre yazacak ama data olmayacak.
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);

        }

        [SecuredOperation("car.get,car,admin")]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        [SecuredOperation("car.get,car,admin")]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [SecuredOperation("car.get,car,admin")]
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        [SecuredOperation("car.update,car,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.get,car,admin")]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [SecuredOperation("car.get,car,admin")]
        public IDataResult<int> GetModelYearForOldestCar()
        {
            var result = _carDal.GetAll().OrderBy(c => c.ModelYear).First();

            return new SuccessDataResult<int>(result.ModelYear);
        }

        public IResult IsCarExists(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);

            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
