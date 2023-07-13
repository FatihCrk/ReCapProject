using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //bu kısmı fluent validator tarafına devrettim
            //if (car.DailyPrice <= 0)
            //{
            //    return new ErrorResult(Messages.CarDailyPriceInvalid);
            //}
            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarList);
        }

        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetCarByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetCarByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(new List<CarDetailDto>(), Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetCarByColorId(int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.ColorId == colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(new List<CarDetailDto>(), Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        public IDataResult<List<CarDetailDto>> CarListBrandIdColorId(int brandId, int colorId)
        {
            var results = _carDal.GetCarDetails(c => c.ColorId == colorId && c.BrandId == brandId);
            if (results.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(new List<CarDetailDto>());
            }
            return new SuccessDataResult<List<CarDetailDto>>(results);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId)
        {
            var result = _carDal.GetCarDetails(c => c.Id == carId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(new List<CarDetailDto>(), Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Add(car);

                if (car.DailyPrice < 0)
                {
                    throw new Exception(Messages.CarDailyPriceInvalid);
                }

                Add(car);

                return null;
            }
        }


    }
}
