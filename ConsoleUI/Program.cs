using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
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


            //var rn = new Random();
            
            //for (int i = 0; i < 100; i++)
            //{
            //    DateTime date2 = new DateTime(rn.Next(2019, 2021), rn.Next(1, 12), rn.Next(1, 28));
            //    DateTime date1 = new DateTime(rn.Next(2019, 2021), rn.Next(1, 12), rn.Next(1, 28));


            //    rentalManager.Add(new Rental()
            //    {
            //        CarId = new Random().Next(1, 250),
            //        CustomerId = new Random().Next(1, 10),
            //        RentDate = date1,
            //        ReturnDate = date2
            //    });
            //}

            Console.WriteLine("-------------------------------userManager.GetAll()-------------------------------");

            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName + " " + users.LastName + " " + users.Email);
            }

            Console.WriteLine("-------------------------------customerManager.GetAll()-------------------------------");

            foreach (var Customers in customerManager.GetAll().Data)
            {
                Console.WriteLine(@"Müşteri Şirketi: "+Customers.CompanyName+ " Kullanıcı Id: "+Customers.UserId);
            }

            Console.WriteLine("-------------------------------carManager.GetCarDetailDtos-------------------------------");

            foreach (var cars in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(@"Model Yılı: " + cars.ModelYear.Year + " / Markası: " + cars.BrandName + " / Rengi: " + cars.ColorName +
                    " / Günlük Kiralama Bedeli: " + cars.DailyPrice + " TL / Açıklama: " + cars.Descriptions+" Id "+cars.Id);
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



            //for (int i = 0; i < 250; i++)
            //{
            //    carmanager.add(new car()
            //    {
            //        brandıd = new random().next(1, 10),
            //        colorıd = new random().next(1, 10),
            //        dailyprice = new random().next(75, 750),
            //        descriptions = "auto added",
            //        modelyear = new datetime().addyears(new random().next(1998, 2021))
            //    });
            //}
        }
    }
}

//carManager.Delete(new Car() { Id = new Random().Next(1652, 1826) });
//carManager.Update(new Car() { Id = new Random().Next(1652, 1826), BrandId = new Random().Next(1, 10), ColorId = new Random().Next(1, 10), DailyPrice = new Random().Next(50, 750), Descriptions = "Auto Added", ModelYear = new DateTime().AddYears(new Random().Next(1998, 2021)) });
// rasgele veri tabanına araç yerleştirme fonksiypnu


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