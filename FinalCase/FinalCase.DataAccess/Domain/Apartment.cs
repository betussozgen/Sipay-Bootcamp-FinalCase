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

    public string Block { get; set; }
    public bool IsOccupied { get; set; } //Dolu-Bos
    public string Type { get; set;} //2+1
    public int FloorNo { get; set;}
    public int ApartmentNo { get; set; }
    public bool IsOwner { get; set; } //kiracı-Sahibi

    // Navigasyon Property
    //public List<Payment> Payments { get; set; }
    public virtual List<User> Users { get; set; }

    public virtual ICollection<DueInvoice> DueInvoices { get; set; } 

    // Apartment sınıfına Bill adında bir ICollection<Bill> özelliği ekleme
    //public virtual ICollection<Bill> Bill { get; set; }

    // Apartment sınıfına Dues adında bir ICollection<Due> özelliği ekleme
    //public virtual ICollection<Due> Dues { get; set; }
}


public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {

        // Block alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.Block)
               .HasColumnName("Block")
               .HasMaxLength(50) // Örnek olarak, maksimum uzunluğu 50 karakter olarak belirtiyoruz.
               .IsRequired(true); // Bu alanın zorunlu olduğunu belirtiyoruz.

        // Status alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.IsOccupied)
               .HasColumnName("Status")
               .IsRequired(true);

        // Type alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.Type)
               .HasColumnName("Type")
               .HasMaxLength(50)
               .IsRequired(true);

        // FloorNo alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.FloorNo)
               .HasColumnName("FloorNo")
               .IsRequired(true);

        // ApartmentNo alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.ApartmentNo)
               .HasColumnName("ApartmentNo")
               .IsRequired(true);

        // OwnerOrTenant alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.IsOwner)
               .HasColumnName("OwnerOrTenant")
               .HasMaxLength(50)
               .IsRequired(true);

    }
}


