// See https://aka.ms/new-console-template for more information

using Business.Concrete;

using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


//BrandManager bm = new BrandManager(new EfBrandDal());

//foreach (var brand in bm.GetAll())
//{
//    Console.WriteLine(brand.BrandName);
//}

CarTest();


static void CarTest()
{
    //CarManager cm = new CarManager(new EfCarDal(),
    //                               new BrandManager(new EfBrandDal()),
    //                               new CarImageManager(new EfCarImageDal()) );

    //var result = cm.GetAllByCarDetails();

    //if (result.Success == true)
    //{
    //    foreach (var carDetailDto in result.Data)
    //    {
    //        Console.WriteLine(carDetailDto.CarName + "--" + carDetailDto.BrandName + " *** " + carDetailDto.ColorName);
    //    }
    //}
    //else { Console.WriteLine(result.Message); }

    //foreach (var car in cm.GetAllByCarDetails().Data)
    //{
    //    Console.WriteLine(car.CarName + "--" + car.BrandName + " *** " + car.ColorName);
    //}
}

