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
    public bool Status { get; set; } //Dolu-Bos
    public string Type { get; set;} //2+1
    public int FloorNo { get; set;}
    public int ApartmentNo { get; set; }
    public string OwnerOrTenant { get; set; } //kiracı-Sahibi

    // Apartment sınıfına Bill adında bir ICollection<Bill> özelliği ekleme
    public virtual ICollection<Bill> Bill { get; set; }

    // Apartment sınıfına Dues adında bir ICollection<Due> özelliği ekleme
    public virtual ICollection<Due> Dues { get; set; }
}


public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {

        // Block alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.Block)
               .HasColumnName("Block")
               .HasMaxLength(50) // Örnek olarak, maksimum uzunluğu 50 karakter olarak belirtiyoruz.
               .IsRequired(); // Bu alanın zorunlu olduğunu belirtiyoruz.

        // Status alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.Status)
               .HasColumnName("Status")
               .IsRequired();

        // Type alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.Type)
               .HasColumnName("Type")
               .HasMaxLength(50)
               .IsRequired();

        // FloorNo alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.FloorNo)
               .HasColumnName("FloorNo")
               .IsRequired();

        // ApartmentNo alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.ApartmentNo)
               .HasColumnName("ApartmentNo")
               .IsRequired();

        // OwnerOrTenant alanı için sütun adı ve diğer ayarlar
        builder.Property(a => a.OwnerOrTenant)
               .HasColumnName("OwnerOrTenant")
               .HasMaxLength(50)
               .IsRequired();

    }
}


