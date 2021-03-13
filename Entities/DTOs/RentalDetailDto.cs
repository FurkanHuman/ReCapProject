using Core.Entities.Abstract;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturntDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
    }
}
