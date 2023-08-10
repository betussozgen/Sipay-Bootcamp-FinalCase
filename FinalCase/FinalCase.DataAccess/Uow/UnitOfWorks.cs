using FinalCase.Base;
using FinalCase.DataAccess;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Uow;

public class UnitOfWork : IUnitOfWork
{


    private readonly FinalCaseDbContext dbContext;

    

    public UnitOfWork(FinalCaseDbContext dbContext)
    {
        this.dbContext = dbContext;

        ApartmentRepository = new GenericRepository<Apartment>(dbContext);
        BillRepository = new GenericRepository<Bill>(dbContext);
        DueRepository = new GenericRepository<Due>(dbContext);
        MessageRepository = new GenericRepository<Message>(dbContext);
        PaymentRepository = new GenericRepository<Payment>(dbContext);
        UserRepository = new GenericRepository<User>(dbContext);
        //UserLogRepository = new GenericRepository<UserLog>(dbContext);
    }

    public void Complete()
    {
        dbContext.SaveChanges();
    }

    //public void CompleteWithTransaction()
    //{
    //    using (var dbTransaction = dbContext.Database.BeginTransaction())
    //    {
    //        try
    //        {
    //            dbContext.SaveChanges();
    //            dbTransaction.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            dbTransaction.Rollback();
    //            //Log.Error(ex, "CompleteWithTransaction");
    //        }
    //    }
    //}

    public IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : BaseModel
    {
        return new GenericRepository<Entity>(dbContext);
    }

    public IGenericRepository<Apartment> ApartmentRepository { get; private set; }
    public IGenericRepository<Bill> BillRepository { get; private set; }
    public IGenericRepository<Due>  DueRepository { get; private set; }
    public IGenericRepository<Message> MessageRepository { get; private set; }
    public IGenericRepository<Payment> PaymentRepository { get; private set; }
    public IGenericRepository<User> UserRepository { get; private set; }
    //public IGenericRepository<UserLog> UserLogRepository { get; private set; }
}
