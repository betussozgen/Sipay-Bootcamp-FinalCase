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

    public int UserId { get; set; }
    public string TcNo { get; set; }
    public string Username { get; set; }    
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string VehiclePlateNumber { get; set; }
    public string Role { get; set; }    

    // Navigation properties
    public ICollection<Apartment>Apartments { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Message> SentMessages { get; set; }
    public ICollection<Message> ReceivedMessages { get; set; }
    public ICollection<DebtCredit> DebtsCredits { get; set; }
    

}



public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(u => u.UserId); // Primary key belirleme
        builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired(); // Sütun adı ve zorunlu olduğunu belirleme

        builder.Property(u => u.TcNo).HasMaxLength(11).IsRequired(); // Diğer sütunları da benzer şekilde belirleme
        builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
        builder.Property(u => u.PasswordHash).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Phone).HasMaxLength(20).IsRequired();
        builder.Property(u => u.VehiclePlateNumber).HasMaxLength(20);
        
        //RuleFor(user => user.Role)
        //   .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
        //   .Must(role => role == "User" || role == "Admin").WithMessage("Please ensure the {PropertyName} is either 'User' or 'Admin'.")
        // Navigation properties'in belirtilmesi
        builder.HasMany(u => u.Apartments).WithOne(a => a.Users).HasForeignKey(a => a.UserId);
        builder.HasMany(u => u.Payments).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        builder.HasMany(u => u.SentMessages).WithOne(m => m.Sender).HasForeignKey(m => m.SenderId);
        builder.HasMany(u => u.ReceivedMessages).WithOne(m => m.Receiver).HasForeignKey(m => m.ReceiverId);
        builder.HasMany(u => u.DebtsCredits).WithOne(d => d.User).HasForeignKey(d => d.UserId);

    }
}