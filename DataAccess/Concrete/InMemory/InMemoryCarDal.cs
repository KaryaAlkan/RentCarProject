using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=2,BrandName= "Mercedes Benz",Model = "200 AMG",
                    Color = "White",ModelYear = 2016,DailyPrice= 458,Description="Automatic and Fuel"},
                new Car{CarId=2,BrandId=3,BrandName= "Hyundai",Model = "I20 1.4 CRDi Style",
                    Color = "Red",ModelYear = 2019,DailyPrice= 119,Description="Normal and Diesel"},
                new Car{CarId=3,BrandId=1,BrandName= "Volkswagen",Model = "Passat 1.4 TSI",
                    Color = "Black",ModelYear = 2017,DailyPrice= 330,Description="Normal and Fuel"},
                new Car{CarId=4,BrandId=1,BrandName= "Volkswagen",Model = "Jetta 1.6 TDI Comfortline",
                    Color = "White",ModelYear = 2015,DailyPrice= 270,Description="Semiautomatic and Diesel"},
                new Car{CarId=5,BrandId=2,BrandName= "BMW",Model = "Series 3 318i Prestige",
                    Color = "White",ModelYear = 2016,DailyPrice= 450,Description="Semiautomatic and Fuel"},
                new Car{CarId=6,BrandId=2,BrandName= "Mercedes Benz",Model = "C 180 AMG 7G-Tronic200 AMG",
                    Color = "Black",ModelYear = 2015,DailyPrice= 370,Description="Automatic and Fuel"},
                new Car{CarId=7,BrandId=3,BrandName= "Renault",Model = "Clio 1.0 TCe Icon",
                    Color = "Red",ModelYear = 2020,DailyPrice= 355,Description="Automatic and Fuel"},
                new Car{CarId=8,BrandId=3,BrandName= "Peugeot",Model = "3008 Model:1.5 BlueHDI Allure",
                    Color = "Grey",ModelYear = 2019,DailyPrice= 460,Description="Automatic and Diesel"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.BrandName = car.BrandName;
            carToUpdate.Color = car.Color;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.Model = car.Model;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
