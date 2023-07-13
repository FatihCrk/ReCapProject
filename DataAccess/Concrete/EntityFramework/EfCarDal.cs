using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                IQueryable<CarDetailDto> result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                                                  join brand in context.Brands
                                                  on car.BrandId equals brand.BrandId
                                                  join color in context.Colors
                                                  on car.ColorId equals color.ColorId
                                                  select new CarDetailDto
                                                  {
                                                      Id = car.Id,
                                                      BrandName = brand.BrandName,
                                                      ColorName = color.ColorName,
                                                      DailyPrice = car.DailyPrice,
                                                      Description = car.Description,
                                                      ModelYear = car.ModelYear,
                                                      BrandId = brand.BrandId,
                                                      ColorId = color.ColorId,
                                                      ImagePath = (from i in context.CarImages where i.CarId == car.Id select i.ImagePath).FirstOrDefault(),
                                                      FindexPoint = car.FindexPoint
                                                  };

                return result.ToList();
            }
        }
    }
}
