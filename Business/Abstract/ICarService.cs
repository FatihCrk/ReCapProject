using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByModelYear(int min, int max);
        IDataResult<List<Car>> GetAllByDealyPrice(int dailyPrice);

        IDataResult<List<CarDetailDto>> GetAllByCarDetails();

        IDataResult<Car> GetByCarId(int Id);


        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}