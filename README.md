
## Adım 1: Proje Analizi ve Tasarım: 
Proje Analizi ve Tasarım üzerine düşündükten ve karar verdikten sonra 2. adıma geçtim.
## Adım 2: Veritabanı Oluşturma:
Tabloları oluşturmak için veritabanı sistemi olarak PostreSQL kullandım ve .NET projesinde Entity Framework Core'i kullandım.Entity Framework Core, veritabanı tablolarını C# sınıflarına dönüştürmek ve otomatik olarak veritabanına yansıtmak için kullanışlı bir ORM (Object-Relational Mapping) aracıdır.
Bu proje için 3 adet tablo modeli oluşturmaya karar verdim.
1.Apartment Class:
````
public class Apartment
{
    public int ApartmentId { get; set; }
    public string Block { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public int Floor { get; set; }
    public int ApartmentNumber { get; set; }
    public string OwnerOrTenant { get; set; }
}
```
2.User Class:
```
public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string TcNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CarPlateNumber { get; set; }
}
```
3.Dues and invoices:

```public class DuesInvoice
{
    public int DuesInvoiceId { get; set; }
    public int ApartmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal MonthlyDues { get; set; }
    public decimal WaterBill { get; set; }
    public decimal ElectricityBill { get; set; }
    public decimal GasBill { get; set; }

    public Apartment Apartment { get; set; }
}```

Son olarak, veritabanı bağlantısını ve tabloları oluşturma işlemlerini gerçekleştirmek için DbContext sınıfını oluşturmalıyız:
Burada FinalCaseDbContext sınıfı, DbContext sınıfını kalıtım alarak veritabanı bağlantısını sağlar ve DbSet özellikleri üzerinden tablolara erişim imkanı sunar.
Veritabanı bağlantısını yapılandırmak için proje dosyanızda Startup.cs dosyasını düzenledim.

``` //dbContext
            var dbType = Configuration.GetConnectionString("DbType");
            if (dbType == "Sql")
            {
                var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<FinalCaseDbContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }
            else if (dbType == "PostgreSql")
            {
                var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<FinalCaseDbContext>(opts =>
                  opts.UseNpgsql(dbConfig));
            }
```

Son olarak, veritabanındaki tabloları oluşturmak için Migrations kullanarak veritabanını güncelledim.
PAckage Manager Console'ı açarak, Add-Migration InitialCreate komutunu ardından Update-Database komutunu çalıştırarak veritabanındaki tabloları oluşturdum. Bu işlemlerden sonra artık tablolarım bulunmaktadır.

## Adım 3: 

Repository oluşturdum.


Schema dosyası oluşturdum.
apartment... dosyaları oluşturduldu.

```startap.cs dosyasına mapper config olarak ekledim.

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfig());
            });
            services.AddSingleton(config.CreateMapper());
```