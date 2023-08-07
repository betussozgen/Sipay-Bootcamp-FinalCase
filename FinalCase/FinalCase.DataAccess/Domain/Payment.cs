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
public class Payment
{
    public int PaymentId { get; set; }
    public int UserId { get; set; }
    public int BillId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Bill Bill { get; set; }
}

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.PaymentId); // Primary key belirleme
        builder.Property(p => p.PaymentId).HasColumnName("PaymentId").IsRequired(); // Sütun adı ve zorunlu olduğunu belirleme

        builder.Property(p => p.UserId).IsRequired(); // Diğer sütunları da benzer şekilde belirleme
        builder.Property(p => p.BillId).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(p => p.PaymentAmount).IsRequired();

        builder.HasOne(p => p.User).WithMany(u => u.Payments).HasForeignKey(p => p.UserId); // İlişkiyi belirleme
        builder.HasOne(p => p.Bill).WithMany(b => b.Payments).HasForeignKey(p => p.BillId); // İlişkiyi belirleme

    }
}
