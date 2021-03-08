using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************Welcome To Karyo's Rent A Car Program****************");
            //CarTest();
            //CarAddTest();
            RentACarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new  CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if(result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Model: " + car.BrandName +
                        " Color: " + car.ColorName +
                        " Model Year : " + car.ModelYear +
                        "     Description: " + car.Description +
                        " Daily Price : " + car.DailyPrice + "tl");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            carManager.Add(new Car 
            { CarId = 21,
                BrandId = 2,
                ColorId = 3, 
                ModelYear = 2017, 
                DailyPrice = 346, 
                Description = "Automatic and Diesel" 
            });
            foreach (var car in result.Data)
            {
                Console.WriteLine("Model: " + car.BrandName +
                        " Color: " + car.ColorName +
                        " Model Year : " + car.ModelYear +
                        "     Description: " + car.Description +
                        " Daily Price : " + car.DailyPrice + "tl");
            }
        }

        private static void RentACarTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine("First Name : " + car.FirstName +
                    "LastName : " + car.LastName 
                    + " = " + car.RentDate + 
                    " - "  + car.ReturnDate + 
                    " rented a car.");
            }
            
           
        }
    }
}