using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;
        readonly int rentMoney = 0;
        readonly int descriptionLength = 2;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if (entity.DailyPrice > rentMoney && entity.Descriptions.Length > descriptionLength)
            {
                _carDal.Add(entity);
                Console.WriteLine("Araç Eklendi");
            }
            else 
            {
                Console.WriteLine("Hata aracın kiralama maliyeti " + rentMoney + " dan büyk olmalıdır.\n" +
                    "veya açklaması 2 karakter ve üstü olmalıdır.");
            }
        }

        public void Delete(Car entity)
        {
            Console.WriteLine(entity.Id + "Li araç Silindi ");
            _carDal.Delete(entity);
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetails();
        }
        public void Update(Car entity)
        {
            Console.WriteLine(entity.Id+"Li araç Güncellendi");
            _carDal.Update(entity);
            
        }
    }
}
