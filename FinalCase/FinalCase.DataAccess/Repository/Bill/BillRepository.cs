using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    private readonly FinalCaseDbContext dbContext;
    public BillRepository(FinalCaseDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}