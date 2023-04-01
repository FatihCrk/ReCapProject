﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.CarId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                   
                             select new CarDetailDto { 
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.ColorName,
                              CarImages = context.CarImages.Where(ci => ci.Id == car.CarId).ToList()
                             };

                return result.ToList();

            }
        }
    }
}
