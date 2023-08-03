using FinalCase.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace FinalCase.Command.UserCommand
{
    public class DeleteUserCommand
    {

        private readonly SiteManagementDbContext _dbContext;

        public string UserTcNo { get; set; } 
        public DeleteUserCommand(SiteManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.TcNo == UserTcNo);
            if (user is null)
                throw new InvalidOperationException("Silinecek user bulunamadı");


            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            
        }
    }
}
