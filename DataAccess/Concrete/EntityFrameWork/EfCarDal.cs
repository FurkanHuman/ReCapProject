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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                IQueryable<CarDetailDto> carDetailsDtos = from c in filter is null ? context.Cars : context.Cars.Where(filter)

                                                          join b in context.Brands
                                                          on c.BrandId equals b.Id

                                                          join cl in context.Colors
                                                          on c.ColorId equals cl.Id

                                                          select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = cl.Name, ModelYear = c.ModelYear, Descriptions = c.Descriptions, DailyPrice = c.DailyPrice };
                return carDetailsDtos.ToList();
            }
        }

    }
}
