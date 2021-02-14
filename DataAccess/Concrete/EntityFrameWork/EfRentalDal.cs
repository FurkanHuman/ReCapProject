using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

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

                             join cu in context.Customers
                             on r.CustomerId equals cu.Id

                             join u in context.Users
                             on cu.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.Id,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturntDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
