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

[Table("Role", Schema = "dbo")]
public class Role : BaseModel
{
    public string RoleName { get; set; }

    // Navigasyon Property
    public virtual List<User> Users { get; set; }



    // Role sınıfına Users adında bir koleksiyon özelliği ekleme
    //public virtual ICollection<User> Users { get; set; }

}



public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // RoleName alanı için sütun adı ve diğer ayarlar
        builder.Property(r => r.RoleName)
               .HasColumnName("RoleName")
               .IsRequired(true);

    }
}