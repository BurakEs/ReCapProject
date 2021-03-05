using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> Get(User user);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
