using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
{
    private readonly FinalCaseDbContext dbContext;
    public ApartmentRepository(FinalCaseDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }












    //// Fatura ödemeyen kullanıcıları getiren metot
    //public IEnumerable<User> GetUsersWithUnpaidBills()
    //{
    //    var currentDate = DateTime.Today;

    //    var usersWithUnpaidBills = from user in dbContext.Users
    //                               join payment in dbContext.Payments on user.Id equals payment.UserId into userPayments
    //                               from payment in userPayments.DefaultIfEmpty()
    //                               where payment == null || payment.PaymentDate < currentDate
    //                               select user;

    //    return usersWithUnpaidBills;
    //}

    //// Belirli bir bloktaki daireleri getiren metot
    //public IEnumerable<Apartment> GetApartmentsInBlock(string blockName)
    //{
    //    return dbContext.Apartments.Where(apartment => apartment.Block == blockName).ToList();
    //}
}