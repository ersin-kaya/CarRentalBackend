﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<int> GetModelYearForOldestCar();
        IResult IsCarExists(int carId);

    }
}
