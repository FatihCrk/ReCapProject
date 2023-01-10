using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByModelYear(int min, int max);
        List<Car> GetAllByDealyPrice(int dailyPrice);

        List<CarDetailDto> GetAllByCarDetails();


        void Add(Car carname);



    }
}