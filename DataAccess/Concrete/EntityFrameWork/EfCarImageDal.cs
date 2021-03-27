using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapDBContext>, ICarImageDal
    {
    }
}
