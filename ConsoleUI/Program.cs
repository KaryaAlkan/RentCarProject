using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************Welcome To Karyo's Rent A Car Program****************");
            CarTest();
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
    }
}