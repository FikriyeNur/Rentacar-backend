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
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [FluentValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(UserMessages.UserDeleted);
            }
            return new ErrorResult(UserMessages.FailedUserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<User>>(result);
            }
            return new ErrorDataResult<List<User>>(result, UserMessages.FailedUserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.UserId == userId);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(result, UserMessages.FailedUserById);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.EMail == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(result, UserMessages.FailedEmail);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<OperationClaim>>(result);
            }
            return new ErrorDataResult<List<OperationClaim>>(result, UserMessages.FailedOperationClaimListed);
        }

        [FluentValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UserUpdated);
        }
    }
}
