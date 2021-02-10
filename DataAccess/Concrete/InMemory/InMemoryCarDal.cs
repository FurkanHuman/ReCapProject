using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        readonly List<Car> _Cars;
        public InMemoryCarDal()
        {
            _Cars = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=123,ModelYear=new DateTime(2016),DailyPrice=250,Descriptions="Renault Clio "},
                new Car{Id=2,BrandId=1,ColorId=128,ModelYear=new DateTime(2000),DailyPrice=150,Descriptions="Tofas Şahin"},
                new Car{Id=3,BrandId=2,ColorId=781,ModelYear=new DateTime(2017),DailyPrice=390,Descriptions="Wosvogen Beetle"},
                new Car{Id=4,BrandId=2,ColorId=199,ModelYear=new DateTime(2019),DailyPrice=255,Descriptions="Fiat doblo"},
                new Car{Id=5,BrandId=2,ColorId=199,ModelYear=new DateTime(2019),DailyPrice=395,Descriptions="Fiat linea"},
                new Car{Id=6,BrandId=3,ColorId=988,ModelYear=new DateTime(2021),DailyPrice=500,Descriptions="Skoda Karoq"},
                new Car{Id=7,BrandId=4,ColorId=121,ModelYear=new DateTime(2016),DailyPrice=170,Descriptions="Ford Focus"},
                new Car{Id=8,BrandId=5,ColorId=129,ModelYear=new DateTime(2014),DailyPrice=199,Descriptions="Dacia Logan Mcv"},
                new Car{Id=9,BrandId=4,ColorId=199,ModelYear=new DateTime(2013),DailyPrice=115,Descriptions="Ford B-Max"},
                new Car{Id=10,BrandId=7,ColorId=135,ModelYear=new DateTime(2000),DailyPrice=85,Descriptions="BMW 320i"}
            };
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }


        public void Delete(Car car)
        {
            _Cars.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public Car GetById(Car car)
        {
            return _Cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}