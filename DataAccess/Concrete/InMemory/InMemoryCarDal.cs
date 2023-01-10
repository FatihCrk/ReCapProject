using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car { Id = 1, ColorId = 1, BrandId = 1,DailyPrice=10000,Description ="Honda Civic", ModelYear=2011 },
              new Car { Id = 2, ColorId = 2, BrandId = 2,DailyPrice=150000,Description ="Mercedes Benz", ModelYear=2022 },
              new Car { Id = 3, ColorId = 3, BrandId = 3,DailyPrice=250000,Description ="BMW X5", ModelYear=2022},
            };
        }

     

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }


        public void Delete(Car entity)
        {

           Car carToDelete = null!;
            _cars.SingleOrDefault(c => c.Id == entity.Id);
            _cars.Remove(carToDelete);





            /*-------Foreach ile kullanım----------
             
             
            
            Car carToDelete = null!;
            foreach (var c in _cars)
            {
                if (car.Id == c.Id)
                {
                    carToDelete = c;
                }


            }
            _cars.Remove(carToDelete);
             */


        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

    
        public List<Car> GetAll(Expression<Func<Car, bool>> ?filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id)!;
            carToUpdate.Id = entity.Id;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ModelYear = entity.ModelYear;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
        }
    }
}