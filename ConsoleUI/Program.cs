using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            //ColorUpdateTest();
            //UserAndCustomerAdd();
            //UserAndCustomerDelete(11);
            //RentalAdd();
            GetRentalDetail();
        }

        private static void GetRentalDetail()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetail();
            foreach (var r in result.Data)
            {
                Console.WriteLine($"{r.CarName} // {r.CompanyName}  // {r.BrandName}  // {r.ColorName}  // {r.RentDate}  // {r.ReturnDate} ");
            }
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);
        }



        #region User
        //private static void UserAndCustomerAdd()
        //{

        //    UserManager userManager = new UserManager(new EfUserDal());
        //    User user = new User { FirstName = "Burak", LastName = "Esen", Email = "burak@burak.cm", PasswordHash = "123456" };
        //    userManager.Add(user);

        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    customerManager.Add(new Customer { UserId = userManager.Get(user).Data.Id, CompanyName = "BE Lim." });


 
        //    User userTwo = new User { FirstName = "Samet", LastName = "Öz", Email = "SAMET@SAMET.cm", Password = "123456" };
        //    userManager.Add(userTwo);

        //    customerManager.Add(new Customer { UserId = userManager.Get(userTwo).Data.Id, CompanyName = "Sö Lim." });

        //}
        private static void UserAndCustomerDelete(int userId)
        {

            UserManager userManager = new UserManager(new EfUserDal());
            var user = userManager.GetById(userId).Data;
            

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            if (customerManager.GetByUserId(user.Id).Data != null)
            {
                Console.WriteLine("GİRDİ");
                customerManager.Delete(customerManager.GetByUserId(user.Id).Data);
            }
           
            userManager.Delete(user);

        }
        #endregion

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
