using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _Cars;
        public InMemoryCarDal()
        {
            _Cars = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=123,ModelYear=2016,DailyPrice=250,Description="Renault Clio "},
                new Car{Id=2,BrandId=1,ColorId=128,ModelYear=2000,DailyPrice=150,Description="Tofas Şahin"},
                new Car{Id=3,BrandId=2,ColorId=781,ModelYear=2017,DailyPrice=390,Description="Wosvogen Beetle"},
                new Car{Id=4,BrandId=2,ColorId=199,ModelYear=2019,DailyPrice=255,Description="Fiat doblo"},
                new Car{Id=5,BrandId=2,ColorId=199,ModelYear=2019,DailyPrice=395,Description="Fiat linea"},
                new Car{Id=6,BrandId=3,ColorId=988,ModelYear=2021,DailyPrice=500,Description="Skoda Karoq"},
                new Car{Id=7,BrandId=4,ColorId=121,ModelYear=2016,DailyPrice=170,Description="Ford Focus"},
                new Car{Id=8,BrandId=5,ColorId=129,ModelYear=2014,DailyPrice=199,Description="Dacia Logan Mcv"},
                new Car{Id=9,BrandId=4,ColorId=199,ModelYear=2013,DailyPrice=115,Description="Ford B-Max"},
                new Car{Id=10,BrandId=7,ColorId=135,ModelYear=2000,DailyPrice=85,Description="BMW 320i"}
            };
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car )
        {
            _Cars.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public Car GetById(Car car)
        {
            return _Cars.SingleOrDefault(c => c.Id == c.Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

    }
}