using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from r in context.Rentals

                             join c in context.Cars
                             on r.CarId equals c.Id

                             join co in context.Colors
                             on c.ColorId equals co.Id

                             join cu in context.Customers
                             on r.CustomerId equals cu.Id

                             join u in context.Users
                             on cu.UserId equals u.Id

                             join b in context.Brands
                             on c.BrandId equals b.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturntDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
