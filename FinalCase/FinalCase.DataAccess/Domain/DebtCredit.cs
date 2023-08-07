using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Domain;

[Table("DebtCredit", Schema = "dbo")]
public class DebtCredit
{
    public int DebtCreditId { get; set; }
    public int UserId { get; set; }
    public string Month { get; set; }
    public decimal DebtAmount { get; set; }
    public decimal CreditAmount { get; set; }

    // Navigation property
    public User User { get; set; }
}


public class DebtCreditConfiguration : IEntityTypeConfiguration<DebtCredit>
{
    public void Configure(EntityTypeBuilder<DebtCredit> builder)
    {
        builder.HasKey(dc => dc.DebtCreditId); // Primary key belirleme
        builder.Property(dc => dc.DebtCreditId).HasColumnName("DebtCreditId").IsRequired(); // Sütun adı ve zorunlu olduğunu belirleme

        builder.Property(dc => dc.UserId).IsRequired(); // Diğer sütunları da benzer şekilde belirleme
        builder.Property(dc => dc.Month).HasMaxLength(50).IsRequired();
        builder.Property(dc => dc.DebtAmount).IsRequired();
        builder.Property(dc => dc.CreditAmount).IsRequired();

        builder.HasOne(dc => dc.User).WithMany(u => u.DebtsCredits).HasForeignKey(dc => dc.UserId); // İlişkiyi belirleme

    }
}