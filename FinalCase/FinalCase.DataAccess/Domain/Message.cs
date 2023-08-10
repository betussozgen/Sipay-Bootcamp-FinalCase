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
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string MessageContent { get; set; }
    public MessageStatus Status { get; set; }

    // Navigation properties
    public User Sender { get; set; }
    public User Receiver { get; set; }

}
public enum MessageStatus
{
    Unread,
    Read
}




public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages", "dbo"); // Tablo adı ve şema belirleme

        builder.HasKey(m => m.MessageId); // Primary key belirleme
        builder.Property(m => m.MessageId).HasColumnName("MessageId").IsRequired(); // Sütun adı ve zorunlu olduğunu belirleme

        builder.Property(m => m.SenderId).IsRequired(); // Diğer sütunları da benzer şekilde belirleme
        builder.Property(m => m.ReceiverId).IsRequired();
        builder.Property(m => m.MessageContent).HasMaxLength(1000).IsRequired();
        builder.Property(m => m.Status).IsRequired();

        builder.HasOne(m => m.Sender).WithMany(u => u.SentMessages).HasForeignKey(m => m.SenderId); // İlişkiyi belirleme
        builder.HasOne(m => m.Receiver).WithMany(u => u.ReceivedMessages).HasForeignKey(m => m.ReceiverId); // İlişkiyi belirleme

    }
}
