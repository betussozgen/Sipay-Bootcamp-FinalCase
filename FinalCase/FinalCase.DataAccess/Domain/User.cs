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

    // Navigasyon Property
    public Role Role { get; set; }
    public Apartment Apartment { get; set; }
    //public List<Payment> Payments { get; set; }
    public virtual List<Message> Messages { get; set; }



    // RoleID adında bir özellik ekleyerek Role ile ilişkilendirme sağlanıyor
    public int RoleID { get; set; }



    // User sınıfına Payments adında bir ICollection<Payment> özelliği ekleme
    //public virtual ICollection<Payment> Payments { get; set; }
    //public virtual Role Roles { get; set; }

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
               .HasMaxLength(50)
               .IsRequired(true);

        // Surname alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.Surname)
               .HasColumnName("Surname")
               .HasMaxLength(50)
               .IsRequired(true);

        // Email alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.Email)
               .HasColumnName("Email")
               .IsRequired(true);

        // PhoneNumber alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.PhoneNumber)
               .HasColumnName("PhoneNumber")
               .IsRequired(true);

        // CarInfo alanı için sütun adı ve diğer ayarlar
        builder.Property(u => u.CarInfo)
               .HasColumnName("CarInfo")
               .IsRequired(true);

        // Roles tablosu ile ilişkiyi belirleme (Foreign Key)
        builder.HasOne(u => u.Role)
               .WithMany(u => u.Users)
               .HasForeignKey(u => u.RoleID)
               .IsRequired();

        // Apartment ile ilişki belirtme
        builder.HasOne(u => u.Apartment)
            .WithMany(a => a.Users)
            .HasForeignKey(u => u.Apartment)
            .IsRequired(false); // Eğer ilişki zorunlu değilse IsRequired(false) yapabilir.

        //// Payments ile ilişki belirtme (Birden fazla ödeme olabilir)
        //builder.HasMany(u => u.Payments)
        //    .WithOne(p => p.Users)
        //    .HasForeignKey(p => p.UserId)
        //    .IsRequired();

        // Messages ile ilişki belirtme (Birden fazla mesaj olabilir)
        builder.HasMany(u => u.Messages)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId)
            .IsRequired();
    }
}