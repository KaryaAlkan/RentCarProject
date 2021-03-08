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
                             on u.UserId equals c.UserId
                             join r in context.Rentals
                             on c.CustomerId equals r.CustomerId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = r.CarId,
                                 UserId = u.UserId,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.RentDate

                             };
                return result.ToList();

                
            }
        }
    }
}
