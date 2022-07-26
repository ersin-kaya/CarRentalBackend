using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [SecuredOperation("rental.add,rental,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = IsReturnDateNull(rental.CarId);

            if (result.Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else if (result.Message == Messages.CarNotFound)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            return new ErrorResult(Messages.TheCarIsAlreadyRented);
        }

        [SecuredOperation("rental.delete,rental,admin")]
        [CacheRemoveAspect("IRentalService.Get", "IRentalService.IsReturnDateNull")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        
        [SecuredOperation("rental.get,rental,admin")]
        [CacheAspect]
        [PerformanceAspect(2)]  //2 seconds
        public IDataResult<List<Rental>> GetAll()
        {
            //Thread.Sleep(2000); //for performance test
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        
        [SecuredOperation("rental.get,rental,admin")]
        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == rentalId));
        }
        
        [SecuredOperation("rental.isreturndatenull,rental,admin")]
        [CacheAspect]
        public IResult IsReturnDateNull(int carId)
        {
            var checkCar = _carService.IsCarExists(carId);

            if (checkCar.Success)
            {
                var result = _rentalDal.GetAll(r => r.CarId == carId).OrderByDescending(r => r.RentDate).FirstOrDefault();

                if (result == null || result.ReturnDate != null)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
            }
            return new ErrorResult(Messages.CarNotFound);

        }

        [SecuredOperation("rental.update,rental,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get", "IRentalService.IsReturnDateNull")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [TransactionScopeAspect]
        [SecuredOperation("rental,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get", "IRentalService.IsReturnDateNull")]
        public IResult TransactionalOperation(Rental rental)
        {
            _rentalDal.Update(rental);
            _rentalDal.Add(rental); //with id
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
