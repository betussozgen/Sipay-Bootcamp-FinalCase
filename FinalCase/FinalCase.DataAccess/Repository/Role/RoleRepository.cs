using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly FinalCaseDbContext dbContext;

    public RoleRepository(FinalCaseDbContext dbContext) :base(dbContext)    
    {
        this.dbContext = dbContext;
    }
}