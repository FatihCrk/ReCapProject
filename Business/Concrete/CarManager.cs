using Business.Abstract;
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

        public void Add(Car carname)
        {

            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                if (carname.CarName.Length <= 2)
                {
                    var addedCarname = context.Entry(carname);
                    addedCarname.State = EntityState.Added;

                }
                throw new Exception("Araç adı min 2 karakter olmalıdır.");
            }





        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(b => b.BrandId == id);
        }

        public List<CarDetailDto> GetAllByCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetAllByDealyPrice(int dailyPrice)
        {
            if (dailyPrice > 0)
            {
                return _carDal.GetAll(g=>g.DailyPrice == dailyPrice);
            }

            else
            {
                throw new Exception("Araç Günlük min fiyarı 0'dan büyük olmalıdır.");
            }
        }

        public List<Car> GetAllByModelYear(int min, int max)
        {

            return _carDal.GetAll(c => c.ModelYear >= min && c.ModelYear <= max);
        }


    }
}
