using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }

}
