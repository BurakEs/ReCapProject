using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId
                             join k in context.Users
                             on m.UserId equals k.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.Id,
                                 CustomerId = m.CustomerId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 FirstName = k.FirstName,
                                 LastName = k.LastName,
                                 Email = k.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CompanyName = m.CompanyName
                             };
                return result.ToList();
            }
        }
    }

}
