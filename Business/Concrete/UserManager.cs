using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public IResult Add(User user)
        {
            _userdal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User id)
        {
           _userdal.Delete(id);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(b => b.Id == id));
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
