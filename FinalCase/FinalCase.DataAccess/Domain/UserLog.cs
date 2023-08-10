using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FinalCase.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase.Data.Domain;

[Table("UserLog", Schema = "dbo")]
public class UserLog : BaseModel
{
    public string UserName { get; set; }
    public DateTime TransactionDate { get; set; }
    public string LogType { get; set; }
}


public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
{
    public void Configure(EntityTypeBuilder<UserLog> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.InsertDate).IsRequired(true);

        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.TransactionDate).IsRequired(true);
        builder.Property(x => x.LogType).IsRequired(true).HasMaxLength(20);
    }
}