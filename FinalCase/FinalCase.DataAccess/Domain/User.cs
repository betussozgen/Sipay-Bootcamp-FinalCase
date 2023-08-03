using FinalCase.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Domain;

[Table("User", Schema = "dbo")]

public class User : BaseModel
{
   
    public string TcNo { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool CarInfo { get; set; }

    // RoleID adında bir özellik ekleyerek Role ile ilişkilendirme sağlanıyor
    public int RoleID { get; set; }

    // User sınıfına Payments adında bir ICollection<Payment> özelliği ekleme
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual Role Roles { get; set; }

}



public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // TcNo alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.TcNo)
               .HasColumnName("TcNo")
               .ValueGeneratedNever()
               .HasMaxLength(11) // TcNo alanı maksimum 11 karakter uzunluğunda olacak
               .IsRequired(true);
        // TcNo alanının benzersiz (unique) olması için indeks oluşturma
        builder.HasIndex(u => u.TcNo).IsUnique();

        // Name alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.Name)
               .HasColumnName("Name")
               .IsRequired();

        // Surname alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.Surname)
               .HasColumnName("Surname")
               .IsRequired();

        // Email alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.Email)
               .HasColumnName("Email")
               .IsRequired();

        // PhoneNumber alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.PhoneNumber)
               .HasColumnName("PhoneNumber")
               .IsRequired();

        // CarInfo alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.CarInfo)
               .HasColumnName("CarInfo")
               .IsRequired();

        // Roles tablosu ile ilişkiyi belirleme (Foreign Key)
        builder.HasOne(u => u.Roles)
               .WithMany(u => u.Users)
               .HasForeignKey(u => u.RoleID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}