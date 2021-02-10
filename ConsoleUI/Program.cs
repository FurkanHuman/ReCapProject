using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {       
        static void Main(string[] args)
        {
            var randomrenk = new Random().Next(1, 10);
            var randommarka = new Random().Next(1, 10);
            var randoprice = new Random().Next(1, 1000);
            var datetimerandom = new DateTime(2019);

            CarManager carManager = new CarManager(new EfCarDal());

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            ColorManager colorManager = new ColorManager(new EfColorDal());
            








/*
            for (int i = 0; i < 25; i++)
            {  Car car = new Car {ColorId=randomrenk,BrandId=randommarka, Descriptions="Autoadd",DailyPrice=randoprice,ModelYear=datetimerandom};

            carManager.Add(car);   foreach (var cars in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(@"Model Yılı: "+cars.ModelYear.Year+ " / Markası: "+cars.BrandName+ " / Rengi: "+cars.ColorName+ 
                    " / Günlük Kiralama Bedeli"+cars.DailyPrice+" TL / Açıklama" +cars.Descriptions);
            }
            

            }

  */        

         
        }
    }
}