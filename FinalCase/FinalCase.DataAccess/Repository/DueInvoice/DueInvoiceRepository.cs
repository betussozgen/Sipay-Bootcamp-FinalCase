using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class DueInvoiceRepository : GenericRepository<DueInvoice>, IDueInvoiceRepository
{
    private readonly FinalCaseDbContext dbContext;
    public DueInvoiceRepository(FinalCaseDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}

