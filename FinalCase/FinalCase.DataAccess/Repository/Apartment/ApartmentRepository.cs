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
}