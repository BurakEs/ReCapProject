using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarGetCarDetailTest();
            //CarGetAllTest();
            //CarGetByIdTest(2);
            //CarAddingTest();
            //BrandAddingTest();
            //BrandGetById(3);
            //BrandUpdateTest();
            //ColorAddingTest();
            //ColorGetById(2);
            ColorUpdateTest();
        }

        #region Brand
        private static void ColorAddingTest()
        {

            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Add(new Color { ColorName = "Kırmızı" });
            Console.WriteLine(result.Message);

            result = colorManager.Add(new Color { ColorName = "Siyah" });
            Console.WriteLine(result.Message);

            result = colorManager.Add(new Color { ColorName = "Kırmızı" });
            Console.WriteLine(result.Message);

            result = colorManager.Add(new Color { ColorName = "Siyah" });
            Console.WriteLine(result.Message);
        }
        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Update(new Color { Id = 3, ColorName = "Fiat" });
            Console.WriteLine(result.Message);

            result =colorManager.Update(new Color { Id = 4, ColorName = "Tofaş" });
            Console.WriteLine(result.Message);
        }
        private static void ColorGetById(int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetById(id);
            Console.WriteLine($"{result.Data.Id} // {result.Data.ColorName} ");
        }
        #endregion

        #region Brand
        private static void BrandAddingTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Peugeot" });
            brandManager.Add(new Brand { BrandName = "Tesla" });
        }
        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id =3, BrandName = "Fiat" });
            brandManager.Update(new Brand { Id =4, BrandName = "Tofaş" });
        }
        private static void BrandGetById(int id)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(id);
            Console.WriteLine($"{result.Data.Id} // {result.Data.BrandName} ");
        }
        #endregion

        #region Car

        private static void CarAddingTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 21, CarName = "a", ModelYear = 1985 ,Description="Açıklamasız"});
            carManager.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 0, CarName = "BbB", ModelYear = 1985, Description = "Açıklamasız" });
            carManager.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 21, CarName = "Volvo", ModelYear = 1983, Description = "Açıklamasız" });
        }

        private static void CarGetByIdTest(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(carId);
            Console.WriteLine($"{result.Data.Id} // {result.Data.CarName} // {result.Data.ModelYear} ");
        }
        private static void CarGetCarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var c in result.Data)
            {
                Console.WriteLine($"{c.CarId} // {c.CarName} // {c.BrandName} // {c.ColorName} // {c.DailyPrice}");
            }
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var c in result.Data)
            {
                Console.WriteLine($"{c.Id} // {c.CarName} // {c.ModelYear} ");
            }
        }
        #endregion
    }
}
