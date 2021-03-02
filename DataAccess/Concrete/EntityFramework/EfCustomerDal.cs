using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RecapContext>, ICustomerDal
    {

    }
}
