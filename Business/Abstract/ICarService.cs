using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<Car> GetByCarId(int carId);

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);

        IResult TransactionalOperation(Car car);

    }
}