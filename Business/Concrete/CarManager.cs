using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
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
        IBrandService _brandService;
        ICarImageService _carImageService;

        public CarManager(ICarDal cardal, IBrandService brandService, ICarImageService carImageService)
        {
            _carDal = cardal;
            _brandService = brandService;
            _carImageService = carImageService;

        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(

                CheckIfCarCountOfBrand(car.BrandId), 
                VehicleControlWithTheSameName(car.CarName), 
                CheckingTheNumberOfBrands(car.BrandId)

              );


            if (result != null)
            {
                return result;
            }

           
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetAllByCarDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetAllByDealyPrice(int dailyPrice)
        {
            if (dailyPrice < 10)
            {
                return new ErrorDataResult<List<Car>>(Messages.PriceMustBeGreaterThan);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(g => g.DailyPrice == dailyPrice));
        }

        public IDataResult<List<Car>> GetAllByModelYear(int min, int max)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear >= min && c.ModelYear <= max));
        }

        public IDataResult<Car> GetByCarId(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IResult Update(Car car)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                if (car.CarName.Length >= 2)
                {
                    var updatedCarname = context.Entry(car);
                    updatedCarname.State = EntityState.Modified;

                }
                throw new Exception("Araç ismi min 2 karakter olmalıdır.");
            }
        }


        private IResult CheckIfCarCountOfBrand(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId <= brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult VehicleControlWithTheSameName(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ThereIsAVehicleWithSameName);
            }

            return new SuccessResult();
        }


        private IResult CheckingTheNumberOfBrands(int brandId) {

            var result = _brandService.GetAll().Data;

            if (result.Count() >= 10)
            {

                return new ErrorResult(Messages.BrandLimitExceeded);
            }

            return new SuccessResult();
        
        }


       
    }
}
