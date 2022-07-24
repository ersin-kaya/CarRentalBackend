using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("carimage.add,carimage,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckCountOfCarImagesForAdding(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;   //refactor?

            carImage.ImagePath = _fileHelper.Upload(file, Paths.CarImagesPath).Data;    //refactor

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.delete,carimage,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {

            _fileHelper.Delete(Paths.CarImagesPath + GetPathOfCarImage(carImage.Id));

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [SecuredOperation("carimage.get,carimage,admin")]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        [SecuredOperation("carimage.get,carimage,admin")]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {

            IResult result = BusinessRules.Run(CheckCountOfCarImagesForListing(carId));

            if (result != null)
            {
                return GetDefaultCarImage(carId);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        [SecuredOperation("carimage.get,carimage,admin")]
        [CacheAspect]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == carImageId));
        }

        [SecuredOperation("carimage.get,carimage,admin")]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetDefaultCarImage(int forcedCarId)
        {
            var defaultCarImage = new List<CarImage>();
            defaultCarImage.Add(new CarImage { Id = 0, CarId = forcedCarId, Date = DateTime.Now, ImagePath = "defaultCarImage.png" }); //refactor - ImagePath

            return new SuccessDataResult<List<CarImage>>(defaultCarImage);
        }

        [SecuredOperation("carimage.update,carimage,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.Date = DateTime.Now;   //refactor?


            string filePath = Paths.CarImagesPath + GetPathOfCarImage(carImage.Id); //refactor?

            carImage.ImagePath = _fileHelper.Update(file, Paths.CarImagesPath, filePath).Data;    //refactor

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCountOfCarImagesForAdding(int carId)
        {
            if (!(GetCountOfCarImages(carId) < 5))
            {
                return new ErrorResult(Messages.CountOfCarImagesError);
            }
            return new SuccessResult();
        }

        private IResult CheckCountOfCarImagesForListing(int carId)
        {
            if (GetCountOfCarImages(carId) > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private int GetCountOfCarImages(int carId)
        {
            return _carImageDal.GetAll(i => i.CarId == carId).Count;
        }

        private string GetPathOfCarImage(int id)
        {
            return _carImageDal.Get(i => i.Id == id).ImagePath;
        }
    }
}
