using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------- GetAll() Metodu -----------------------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var CarItem in carManager.GetAll())
            {
                Console.WriteLine(CarItem.ModelYear + " " + CarItem.ColorId + " " + CarItem.DailyPrice + " " + CarItem.Description+ " Adlı araç");
            }
                       
            Car carAdd = new Car { BrandId = 9, ColorId=976, DailyPrice=157, Description="Tofas Doğan", Id=10};
            Console.WriteLine("----------------------------- Add() Metodu -----------------------------");

            foreach (var CarItem in carManager.GetAll())
            {
                Console.WriteLine(CarItem.ModelYear + " " + CarItem.ColorId + " " + CarItem.DailyPrice + " " + CarItem.Description + " Adlı araç");
            }



        }
    }
}
