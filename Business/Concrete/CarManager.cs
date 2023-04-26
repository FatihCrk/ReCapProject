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

        //[ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           

                      _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

          

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect(duration: 10, Priority = 1)]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            // PerformanceAspect'i test etmek için fonksiyonu 500sn uyutuyoruz.
            //Thread.Sleep(5000);

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedSuccessful);
        }

        public IDataResult<Car> GetByCarId(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == CarId), Messages.ListedSuccessful);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ListedSuccessful);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(BrandId), Messages.ListedSuccessful);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(ColorId), Messages.ListedSuccessful);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            if (brandId != 0 && colorId != 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandAndColorId(brandId, colorId), Messages.ListedSuccessful);
            }
            else if (brandId != 0 && colorId == 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(brandId), Messages.ListedSuccessful);
            }
            else if (brandId == 0 && colorId != 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(colorId), Messages.ListedSuccessful);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ListedSuccessful);
            }

        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int CarId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId(CarId), Messages.ListedSuccessful);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == BrandId), Messages.ListedSuccessful);

        }
        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId), Messages.ListedSuccessful);

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccessful);
        }


        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            // Add işleminde CarId gönderdiğimiz için hata veriyor
            // transactionı geri alıyor.
            //_carDal.Add(car);
            // Silme işlemi yapıldığında transaction başarılı oluyor.
            _carDal.Delete(car);
            return new SuccessResult(Messages.UpdateSuccessful);
        }

    }
}
