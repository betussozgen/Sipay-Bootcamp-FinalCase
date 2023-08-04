using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;
public class DueRepository : GenericRepository<Due>, IDueRepository
{
    private readonly FinalCaseDbContext dbContext;
    public DueRepository(FinalCaseDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;

    }


}
