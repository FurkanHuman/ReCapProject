using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Cart : IEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CartNumber { get; set; }
        public short Month { get; set; }
        public short Year { get; set; }
        public short CVV { get; set; }
        public int TotalPrice { get; set; }
    }
}
