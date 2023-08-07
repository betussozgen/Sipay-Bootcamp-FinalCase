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

[Table("Apartment", Schema ="dbo")]
public class Apartment : BaseModel
{
    public int ApartmentId { get; set; }
    public string BlockNumber { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public int FloorNumber { get; set; }
    public int ApartmentNumber { get; set; }
    public string OwnerOrTenant { get; set; }
    public int UserId { get; set; } // User'a referans sütunu

    // Navigation properties
    public User Users { get; set; }
    public ICollection<Due> Dues { get; set; }
    public ICollection<Bill> Bills { get; set; }
}


public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {

        builder.HasKey(a => a.ApartmentId); // Primary key belirleme
        builder.Property(a => a.ApartmentId).HasColumnName("ApartmentId").IsRequired(); // Sütun adı ve zorunlu olduğunu belirleme

        builder.Property(a => a.BlockNumber).HasMaxLength(50).IsRequired(); // Diğer sütunları da benzer şekilde belirleme
        builder.Property(a => a.Status).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Type).HasMaxLength(50).IsRequired();
        builder.Property(a => a.FloorNumber).IsRequired();
        builder.Property(a => a.ApartmentNumber).IsRequired();
        builder.Property(a => a.OwnerOrTenant).HasMaxLength(50).IsRequired();

        // İlişkileri konfigüre etme
        builder.HasOne(a => a.Users).WithMany(u => u.Apartments).HasForeignKey(a => a.UserId); // Apartment ile User ilişkisini belirtme
        builder.HasMany(a => a.Dues).WithOne(d => d.Apartment).HasForeignKey(d => d.ApartmentId);
        builder.HasMany(a => a.Bills).WithOne(b => b.Apartment).HasForeignKey(b => b.ApartmentId);


    }
}


