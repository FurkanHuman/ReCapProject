using Core.Entities.Abstract;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturntDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
