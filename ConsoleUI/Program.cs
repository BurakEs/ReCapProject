using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarGetAllTest();
            //CarGetByIdTest(2);
        }

        private static void CarGetByIdTest(int carId)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetById(carId);
            Console.WriteLine($"{result.CarId} // {result.Description} // {result.ModelYear} ");
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetAll();
            foreach (var c in result)
            {
                Console.WriteLine($"{c.CarId} // {c.Description} // {c.ModelYear} ");
            }
        }
    }
}
