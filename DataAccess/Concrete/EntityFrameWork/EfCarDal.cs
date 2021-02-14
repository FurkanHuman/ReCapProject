﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                             on c.BrandId equals b.Id

                             join cl in context.Colors
                             on c.ColorId equals cl.Id

                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = cl.Name, ModelYear = c.ModelYear, Descriptions = c.Descriptions, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }

    }
}
