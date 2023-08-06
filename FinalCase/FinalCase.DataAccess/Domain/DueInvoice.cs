using FinalCase.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Domain;

[Table("DuesInvoice", Schema = "dbo")]

public class DueInvoice : BaseModel
{
    public int DuesInvoiceId { get; set; }
    public int ApartmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal MonthlyDues { get; set; }
    public decimal WaterBill { get; set; }
    public decimal ElectricityBill { get; set; }
    public decimal GasBill { get; set; }

    public Apartment Apartments { get; set; }
}

public class DueInvoıceConfiguration : IEntityTypeConfiguration<DueInvoice>
{
   

    public void Configure(EntityTypeBuilder<DueInvoice> builder)
    {

        // Primary Key belirlenir
        builder.HasKey(di => di.DuesInvoiceId);

        // Daire ile ilişkilendirme
        builder.HasOne(di => di.Apartments)
               .WithMany(a => a.DueInvoices)
               .HasForeignKey(di => di.ApartmentId)
               .OnDelete(DeleteBehavior.Cascade); // Daire silindiğinde ilişkili faturaları da siler

        // Diğer sütunların konfigürasyonu
        builder.Property(di => di.Month).IsRequired();
        builder.Property(di => di.Year).IsRequired();
        builder.Property(di => di.MonthlyDues).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(di => di.WaterBill).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(di => di.ElectricityBill).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(di => di.GasBill).HasColumnType("decimal(18,2)").IsRequired();

    }
}
