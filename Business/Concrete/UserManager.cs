using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (Convert.ToInt32(user.Password) == 4)
            {
                _userDal.Add(user);
                return new SuccessResult(UserMessages.UserAdded);
            }
            else
            {
                return new ErrorResult(UserMessages.FailedUserInformation);
            }
        }

        public IResult Delete(User user)
        {
            if (user != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(UserMessages.UserDeleted);
            }
            else
            {
                return new ErrorResult(UserMessages.FailedUserDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<User>>(result);
            }
            else
            {
                return new ErrorDataResult<List<User>>(result, UserMessages.FailedUserListed);

            }
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.UserId == userId);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            else
            {
                return new ErrorDataResult<User>(result, UserMessages.FailedUserById);

            }
        }

        public IResult Update(User user)
        {
            if (Convert.ToInt32(user.Password) == 4)
            {
                _userDal.Update(user);
                return new SuccessResult(UserMessages.UserUpdated);
            }
            else
            {
                return new ErrorResult(UserMessages.FailedUserInformation);
            }
        }
    }
}
