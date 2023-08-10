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
    public int DuesId { get; set; }
    public int ApartmentId { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string DueStatus { get; set; }
    public decimal Amount { get; set; }

    // Navigation property
    public Apartment Apartment { get; set; }
}
public enum DueStatus
{
    Unpaid = 0,
    Paid = 1,    
}


public class DueConfiguration : IEntityTypeConfiguration<Due>
{
    public void Configure(EntityTypeBuilder<Due> builder)
    {
        builder.ToTable("Due", "dbo"); // Tablo adı ve şema belirleme

        builder.HasKey(d => d.DuesId); // Primary key belirleme
        builder.Property(d => d.DuesId).HasColumnName("DuesId").IsRequired(); // Sütun adı ve zorunlu olduğunu belirleme

        builder.Property(d => d.ApartmentId).IsRequired(); // Diğer sütunları da benzer şekilde belirleme
        builder.Property(d => d.Month).HasMaxLength(50).IsRequired();
        builder.Property(d => d.Amount).IsRequired();

        builder.HasOne(d => d.Apartment).WithMany(a => a.Dues).HasForeignKey(d => d.ApartmentId); // İlişkiyi belirleme

    }
}