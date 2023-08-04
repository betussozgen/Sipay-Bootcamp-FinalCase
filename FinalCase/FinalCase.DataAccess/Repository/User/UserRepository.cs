using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly FinalCaseDbContext dbContext;

    public UserRepository(FinalCaseDbContext dbContext):base(dbContext)
    {
        this.dbContext = dbContext;
    }
}