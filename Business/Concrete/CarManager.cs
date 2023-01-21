using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.UserAdded);
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
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
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
            if (dailyPrice <10)
            {
                return new ErrorDataResult<List<Car>>(Messages.PriceMustBeGreaterThan) ;
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

                if (car.CarName.Length <= 2)
                {
                    var updatedCarname = context.Entry(car);
                    updatedCarname.State = EntityState.Modified;

                }
                throw new Exception("Araç ismi min 2 karakter olmalıdır.");
            }
        }
    }
}
