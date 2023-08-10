using FinalCase.Data.Domain;
using FinalCase.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess;
public class FinalCaseDbContext : DbContext
{
    public FinalCaseDbContext(DbContextOptions<FinalCaseDbContext> options) : base(options)
    {

    }

    //DbSet
    // dbset
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Due> Dues { get; set; }
    public DbSet<Payment> Payments { get; set; }
    //public DbSet<DebtCredit> DebtCredits { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLog> UserLog { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
        modelBuilder.ApplyConfiguration(new BillConfiguration());
        modelBuilder.ApplyConfiguration(new DueConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        //modelBuilder.ApplyConfiguration(new DebtCreditConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        //modelBuilder.ApplyConfiguration(new DueConfiguration());
        //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserLogConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}
