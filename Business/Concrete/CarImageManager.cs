using Business.Abstract;
using Business.Constants;
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

        public IResult Delete(CarImage carImage)
        {

            _fileHelper.Delete(Paths.CarImagesPath + GetPathOfCarImage(carImage));

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {

            IResult result = BusinessRules.Run(CheckCountOfCarImagesForListing(carId));

            if (result != null)
            {
                return GetDefaultCarImage(carId);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == carImageId));
        }

        public IDataResult<List<CarImage>> GetDefaultCarImage(int forcedCarId)
        {
            var defaultCarImage = new List<CarImage>();
            defaultCarImage.Add(new CarImage { Id = 0, CarId = forcedCarId, Date = DateTime.Now, ImagePath = "defaultCarImage.png" }); //refactor - ImagePath

            return new SuccessDataResult<List<CarImage>>(defaultCarImage);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.Date = DateTime.Now;   //refactor?


            string filePath = Paths.CarImagesPath + GetPathOfCarImage(carImage); //refactor?

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

        private string GetPathOfCarImage(CarImage carImage)
        {
            return _carImageDal.Get(i => i.Id == carImage.Id).ImagePath;
        }
    }
}
