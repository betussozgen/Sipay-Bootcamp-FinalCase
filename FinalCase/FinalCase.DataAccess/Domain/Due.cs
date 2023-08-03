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

[Table("Due", Schema = "dbo")]

public class Due : BaseModel
{
 
    public int ApartmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }

    public virtual Apartment Apartments { get; set; }


}


public class DueConfiguration : IEntityTypeConfiguration<Due>
{
    public void Configure(EntityTypeBuilder<Due> builder)
    {
        // ApartmentId alanı için sütun adı ve diğer ayarlar
        builder.Property(d => d.ApartmentId)
               .HasColumnName("ApartmentId")
               .IsRequired();

        // Month alanı için sütun adı ve diğer ayarlar
        builder.Property(d => d.Month)
               .HasColumnName("Month")
               .IsRequired();

        // Year alanı için sütun adı ve diğer ayarlar
        builder.Property(d => d.Year)
               .HasColumnName("Year")
               .IsRequired();

        // Amount alanı için sütun adı ve diğer ayarlar
        builder.Property(d => d.Amount)
               .HasColumnName("Amount")
               .HasColumnType("decimal(18,2)") // Örnek olarak, Amount alanı için decimal(18,2) veri tipi belirtiyoruz.
               .IsRequired();

        // Apartments tablosu ile ilişkiyi belirleme (Foreign Key)
        builder.HasOne(d => d.Apartments)
               .WithMany(a => a.Dues)
               .HasForeignKey(d => d.ApartmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
