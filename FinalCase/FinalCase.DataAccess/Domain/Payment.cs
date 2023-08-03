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

[Table("Payment", Schema = "dbo")]
public class Payment : BaseModel
{
   
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentMethod { get; set; }


    public virtual User Users { get; set; }
}



public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        // UserId alanı için sütun adı ve diğer ayarlar
        builder.Property(p => p.UserId)
               .HasColumnName("UserId")
               .IsRequired();

        // Amount alanı için sütun adı ve diğer ayarlar
        builder.Property(p => p.Amount)
               .HasColumnName("Amount")
               .HasColumnType("decimal(18,2)") // Örnek olarak, Amount alanı için decimal(18,2) veri tipi belirtiyoruz.
               .IsRequired();

        // PaymentDate alanı için sütun adı ve diğer ayarlar
        builder.Property(p => p.PaymentDate)
               .HasColumnName("PaymentDate")
               .IsRequired();

        // PaymentMethod alanı için sütun adı ve diğer ayarlar
        builder.Property(p => p.PaymentMethod)
               .HasColumnName("PaymentMethod")
               .IsRequired();

        // Users tablosu ile ilişkiyi belirleme (Foreign Key)
        builder.HasOne(p => p.Users)
               .WithMany(u => u.Payments)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}