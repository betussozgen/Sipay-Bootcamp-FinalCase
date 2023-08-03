using Microsoft.EntityFrameworkCore;

namespace FinalCase.DBOperations
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SiteManagementDbContext(serviceProvider.GetRequiredService<DbContextOptions<SiteManagementDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                 new User
                 {
                     
                     TcNo = "203422272486",
                     Name = "Betul",
                     Surname = "Ozgen",
                     Email = "betul@mail.com",
                     PhoneNumber = "1234567890",
                     CarInfo = true
                 },
                 new User
                 {
                    
                     TcNo = "20342227247",
                     Name = "Hasan",
                     Surname = "Ozgen",
                     Email = "hasan@mail.com",
                     PhoneNumber = "1234567890",
                     CarInfo = true
                 },
                  new User
                  {
                    
                      TcNo = "20342227248",
                      Name = "Beren",
                      Surname = "Oguzkan",
                      Email = "beren@mail.com",
                      PhoneNumber = "1234567890",
                      CarInfo = false
                  });

                context.SaveChanges();
            }

        }

    }
}
