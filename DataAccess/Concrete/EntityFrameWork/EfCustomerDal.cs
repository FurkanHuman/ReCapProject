using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDBContext>, ICustomerDal
    {
    }
}
