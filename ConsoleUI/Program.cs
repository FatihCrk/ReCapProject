// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


//BrandManager bm = new BrandManager(new EfBrandDal());

//foreach (var brand in bm.GetAll())
//{
//    Console.WriteLine(brand.BrandName);
//}

CarTest();


static void CarTest()
{
    CarManager cm = new CarManager(new EfCarDal());


    foreach (var car in cm.GetAllByCarDetails())
    {
        Console.WriteLine(car.CarName + "--" + car.BrandName + " *** " + car.ColorName);
    }
}

