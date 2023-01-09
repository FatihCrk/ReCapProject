// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//CarTest();
BrandManager bm = new BrandManager(new EfBrandDal());

foreach (var brand in bm.GetAll())
{
    Console.WriteLine(brand.BrandName);
}

static void CarTest()
{
    CarManager cm = new CarManager(new EfCarDal());


    foreach (var car in cm.GetAllByDealyPrice(0))
    {
        Console.WriteLine(car.DailyPrice);
    }
}

