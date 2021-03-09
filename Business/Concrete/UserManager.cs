using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult();
        }

        [CacheAspect(5)]
        [ValidationAspect(typeof(UserValidator))]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        [ValidationAspect(typeof(UserValidator))]
        [SecuredOperation("Manager")]
        [CacheAspect(15)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
