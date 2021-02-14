using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapDBContext>, IBrandDal
    {
    }
}
