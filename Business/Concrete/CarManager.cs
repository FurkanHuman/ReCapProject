using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car entity)
        {
            if (entity.DailyPrice > rentMoney && entity.Descriptions.Length > descriptionLength)
            {
                _carDal.Add(entity);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
                //Console.WriteLine("Hata aracın kiralama maliyeti " + rentMoney + " dan büyk olmalıdır.\n" +
                //    "veya açklaması 2 karakter ve üstü olmalıdır.");
            }
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult();
        }












































        //}

        //public void Add(Car entity)
        //{
        //    if (entity.DailyPrice > rentMoney && entity.Descriptions.Length > descriptionLength)
        //    {
        //        _carDal.Add(entity);
        //        Console.WriteLine("Araç Eklendi");
        //    }
        //    else 
        //    {
        //        Console.WriteLine("Hata aracın kiralama maliyeti " + rentMoney + " dan büyk olmalıdır.\n" +
        //            "veya açklaması 2 karakter ve üstü olmalıdır.");
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    Console.WriteLine(entity.Id + "Li araç Silindi ");
        //    _carDal.Delete(entity);
        //}


        //public List<Car> GetAll()
        //{
        //    return _carDal.GetAll();
        //}

        //public Car GetById(int id)
        //{
        //    return _carDal.Get(c => c.Id == id);
        //}

        //public void Update(Car entity)
        //{
        //    Console.WriteLine(entity.Id+"Li araç Güncellendi");
        //    _carDal.Update(entity);

        //}
    }
}
