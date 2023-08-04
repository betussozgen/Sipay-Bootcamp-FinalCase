using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    private readonly FinalCaseDbContext dbContext;

    public PaymentRepository(FinalCaseDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}