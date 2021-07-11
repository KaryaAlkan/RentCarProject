using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             join r in context.Rentals
                             on c.CustomerId equals r.CustomerId
                             join i in context.CarImages
                             on r.CarId equals i.CarId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = r.CarId,
                                 UserId = u.Id,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.RentDate,
                                 ImagePath = i.ImagePath

                             };
                return result.ToList();

                
            }
        }
    }
}
