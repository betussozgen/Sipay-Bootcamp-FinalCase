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

[Table("Bill", Schema = "dbo")]
public class Bill : BaseModel
{
   
    public int ApartmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }

    public virtual Apartment Apartments { get; set; }

}




public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        // ApartmentId alanı için sütun adı ve diğer ayarlar
        builder.Property(b => b.ApartmentId)
               .HasColumnName("ApartmentId")
               .IsRequired();

        // Month alanı için sütun adı ve diğer ayarlar
        builder.Property(b => b.Month)
               .HasColumnName("Month")
               .IsRequired();

        // Year alanı için sütun adı ve diğer ayarlar
        builder.Property(b => b.Year)
               .HasColumnName("Year")
               .IsRequired();


        builder.Property(b => b.Amount)
               .HasColumnName("Amount")
               .HasColumnType("decimal(18,2)") // Örnek olarak, Amount alanı için decimal(18,2) veri tipi belirtiyoruz.
               .IsRequired();

        // Apartments tablosu ile ilişkiyi belirleme (Foreign Key)
        builder.HasOne(b => b.Apartments)
               .WithMany(a => a.Bill)
               .HasForeignKey(b => b.ApartmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
