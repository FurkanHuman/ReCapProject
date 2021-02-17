using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine("-------------------------------userManager.GetAll()-------------------------------");

            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName + " " + users.LastName + " " + users.Email);
            }


            Console.WriteLine("-------------------------------carManager.GetCarDetailDtos-------------------------------");

            foreach (var cars in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(@"Model Yılı: " + cars.ModelYear.Year + " / Markası: " + cars.BrandName + " / Rengi: " + cars.ColorName +
                    " / Günlük Kiralama Bedeli: " + cars.DailyPrice + " TL / Açıklama: " + cars.Descriptions);
            }

            Console.WriteLine("-------------------------------rentalManager.GetRentalDetailsDtos()-------------------------------");

            foreach (var rentals in rentalManager.GetRentalDetailsDtos().Data)
            {
                Console.WriteLine(@"Arac Id: " + rentals.CarId + " Müşteri Adı / : " + rentals.FirstName + " / Kiralama Tarihi: " + rentals.RentDate +
                    " / geri getirme Tarihi: " + rentals.ReturntDate);
            }

            Console.WriteLine("-------------------------------colorManager.GetAll-------------------------------");

            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine(@"Renk Id: " + colors.Id + " / Renk Adı: " + colors.Name);
            }

            Console.WriteLine("-------------------------------brandManager.GetAll-------------------------------");

            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine(@"Marka Id: " + brands.Id + " / Marka Adı: " + brands.Name);
            }
        }
    }
}
//carManager.Delete(new Car() { Id = new Random().Next(1652, 1826) });
//carManager.Update(new Car() { Id = new Random().Next(1652, 1826), BrandId = new Random().Next(1, 10), ColorId = new Random().Next(1, 10), DailyPrice = new Random().Next(50, 750), Descriptions = "Auto Added", ModelYear = new DateTime().AddYears(new Random().Next(1998, 2021)) });
//// rasgele veri tabanına araç yerleştirme fonksiypnu
//for (int i = 0; i < 250; i++)
//{
//    carManager.Add(new Car()
//    {
//        BrandId = new Random().Next(1, 10),
//        ColorId = new Random().Next(1, 10),
//        DailyPrice = new Random().Next(50, 750),
//        Descriptions = "Auto Added",
//        ModelYear = new DateTime().AddYears(new Random().Next(1998, 2021))
//    });
//}

//while (true)
//{


//    User user = new User()
//    {
//        FirstName = Console.ReadLine().ToUpper(),
//        LastName = Console.ReadLine().ToUpper(),
//        Email = Console.ReadLine(),
//        Password = Console.ReadLine()
//    };
//    userManager.Add(user);
//}