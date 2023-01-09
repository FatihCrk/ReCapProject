using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByModelYear(int min, int max);
        List<Car> GetAllByDealyPrice(int dailyPrice);


        void Add(Car carname);



    }
}