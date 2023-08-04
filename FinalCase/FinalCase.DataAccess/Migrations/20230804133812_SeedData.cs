using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalCase.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.\"User\"(\r\n\t\"Id\", \"TcNo\", \"Name\", \"Surname\", \"Email\", \"PhoneNumber\", \"CarInfo\", \"RoleID\")\r\n\tVALUES(4, '20342227278', 'Betul', 'Ozgenx', 'betulozgen@mail.com', 5541234568, 'true', 1); \r\n \r\n ");
            migrationBuilder.Sql("INSERT INTO dbo.\"User\"(\r\n\t\"Id\", \"TcNo\", \"Name\", \"Surname\", \"Email\", \"PhoneNumber\", \"CarInfo\", \"RoleID\")\r\n\tVALUES(5, '20342227249', 'Betul2', 'Ozgeny', 'betulxozgen@mail.com', 5541234561, 'true', 1); \r\n \r\n ");
            migrationBuilder.Sql("INSERT INTO dbo.\"User\"(\r\n\t\"Id\", \"TcNo\", \"Name\", \"Surname\", \"Email\", \"PhoneNumber\", \"CarInfo\", \"RoleID\")\r\n\tVALUES(6, '20342227246', 'Betul3', 'Ozgen', 'betulyozgen@mail.com', 5541234562, 'false', 2); \r\n \r\n ");
            migrationBuilder.Sql("INSERT INTO dbo.\"User\"(\r\n\t\"Id\", \"TcNo\", \"Name\", \"Surname\", \"Email\", \"PhoneNumber\", \"CarInfo\", \"RoleID\")\r\n\tVALUES(7, '20342227245', 'Betul4', 'Ozgenb', 'betulzozgen@mail.com', 5541234563, 'false', 2); \r\n \r\n ");
            migrationBuilder.Sql("INSERT INTO dbo.\"User\"(\r\n\t\"Id\", \"TcNo\", \"Name\", \"Surname\", \"Email\", \"PhoneNumber\", \"CarInfo\", \"RoleID\")\r\n\tVALUES(8, '20342227244', 'Betul5', 'Ozgent', 'betultozgen@mail.com', 5541234564, 'false', 2); \r\n \r\n ");

            //migrationBuilder.Sql("INSERT INTO dbo.\"Role\"(\r\n\t\"Id\", \"RoleName\")\r\n\tVALUES(1, 'Owner');\r\n \r\n ");
            //migrationBuilder.Sql("INSERT INTO dbo.\"Role\"(\r\n\t\"Id\", \"RoleName\")\r\n\tVALUES(2, 'Tenant');\r\n \r\n ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
