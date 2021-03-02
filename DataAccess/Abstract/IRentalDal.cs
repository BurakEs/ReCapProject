using Core.DataAccess;
using Entities.Concrete;
using Entities.DTos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
    }
}
