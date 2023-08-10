using FinalCase.Base;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;


namespace FinalCase.DataAccess.Uow;


public interface IUnitOfWork
{
    void Complete(); //Save'e karşılık
                     //void CompleteWithTransaction();
    Task<int> SaveChangesAsync();

    IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : BaseModel;
    IGenericRepository<Apartment> ApartmentRepository { get; }
    IGenericRepository<Bill> BillRepository { get; }
    IGenericRepository<Due> DueRepository { get; }
    IGenericRepository<Payment> PaymentRepository { get; }
    IGenericRepository<Message> MessageRepository { get; }
    IGenericRepository<User> UserRepository { get; }
    //IGenericRepository<UserLog> UserLogRepository { get; }



}