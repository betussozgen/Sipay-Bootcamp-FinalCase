using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinalCase.DBOperations
{
    public class SiteManagementDbContext : DbContext
    {
       public SiteManagementDbContext(DbContextOptions<SiteManagementDbContext> options) : base(options) { }    

        public DbSet <User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.TcNo); // TcNo sütununu birincil anahtar olarak belirttik.
        }
    }
}
