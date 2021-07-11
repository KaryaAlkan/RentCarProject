using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Performance;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfBrandLimitExceded());

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactinalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 50)
            {
                throw new Exception(" ");
            }
            Add(car);
            return null;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 2)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId == colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if(result.Data.Count > 25)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }

       
        
    }
}
