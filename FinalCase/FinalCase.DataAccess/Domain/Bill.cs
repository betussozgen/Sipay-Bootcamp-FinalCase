using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Domain;

[Table("Bill", Schema = "dbo")]
public class Bill
{
    public int BillId { get; set; }
    public int ApartmentId { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string Amount { get; set; }
    public int BillStatus { get; set; }

    // Navigation property
    public Apartment Apartment { get; set; }

    public virtual List<Payment> Payments { get; set; }
}


public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {


        builder.HasKey(b => b.BillId);

        builder.Property(b => b.ApartmentId)
            .IsRequired();

        builder.Property(b => b.Month)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.Year)
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(b => b.Amount)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(b => b.BillStatus)
            .IsRequired();

        builder.HasOne(b => b.Apartment)
            .WithMany(a => a.Bills)
            .HasForeignKey(b => b.ApartmentId)
            .OnDelete(DeleteBehavior.Restrict);



    }
}