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
            //CarGetAllTest();
            //CarGetByIdTest(2);
            CarAddingTest();

        }

        private static void CarAddingTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 21, Description = "a", ModelYear = 1985 });
            carManager.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 0, Description = "BbB", ModelYear = 1985 });
            carManager.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 21, Description = "Volvo", ModelYear = 1983 });
        }

        private static void CarGetByIdTest(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(carId);
            Console.WriteLine($"{result.Id} // {result.Description} // {result.ModelYear} ");
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var c in result)
            {
                Console.WriteLine($"{c.Id} // {c.Description} // {c.ModelYear} ");
            }
        }
    }
}
