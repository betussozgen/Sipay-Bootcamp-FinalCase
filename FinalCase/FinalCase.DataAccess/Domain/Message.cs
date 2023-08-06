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



[Table("Message", Schema = "dbo")]
public class Message : BaseModel
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime DateSent { get; set; }

    // Foreign Key
    public int UserId { get; set; }

    // Navigasyon Property
    public User User { get; set; }
}




public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        // Subject sütunu
        builder.Property(message => message.Subject)
               .HasColumnName("Subject")
               .HasMaxLength(100) // Maksimum uzunluk 100 karakter
               .IsRequired();    // Zorunlu alan

        // Content sütunu
        builder.Property(message => message.Content)
               .HasColumnName("Content")
               .HasMaxLength(500) // Maksimum uzunluk 500 karakter
               .IsRequired();    // Zorunlu alan

        // IsRead sütunu
        builder.Property(message => message.IsRead)
               .HasColumnName("IsRead")
               .IsRequired();    // Zorunlu alan

        // DateSent sütunu
        builder.Property(message => message.DateSent)
               .HasColumnName("DateSent")
               .IsRequired();    // Zorunlu alan

        // UserId sütunu (Foreign key)
        builder.Property(message => message.UserId)
               .HasColumnName("UserId")
               .IsRequired();    // Zorunlu alan

        // Navigasyon Property

        // User ile ilişki tanımlama (Foreign key ilişkisi)
        builder.HasOne(message => message.User)
               .WithMany(user => user.Messages)
               .HasForeignKey(message => message.UserId)
               .OnDelete(DeleteBehavior.Restrict); // İlişkili tablodan veri silinirse sadece referansı null olarak ayarla

    }
}
