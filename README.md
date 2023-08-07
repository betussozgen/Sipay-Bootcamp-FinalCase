## Adım 1: Proje Analizi ve Tasarım: 
Proje Analizi ve Tasarım üzerine düşünüp, karar verdikten sonra 2. adıma geçtim.
## Adım 2: Veritabanı Oluşturma:
Tabloları oluşturmak için veritabanı sistemi olarak PostreSQL kullandım ve .NET projesinde Entity Framework Core'i kullandım.Entity Framework Core, veritabanı tablolarını C# sınıflarına dönüştürmek ve otomatik olarak veritabanına yansıtmak için kullanışlı bir ORM (Object-Relational Mapping) aracıdır. Bu proje için 3 adet tablo modeli oluşturmaya karar verdim.Bunlar:
1.Apartment Class:

``` 
public class Apartment
{
    public string Block { get; set; }
    public bool IsOccupied { get; set; } //Dolu-Bos
    public string Type { get; set;} //2+1
    public int FloorNo { get; set;}
    public int ApartmentNo { get; set; }
    public bool IsOwner { get; set; } //kiracı-Sahibi

    // Navigasyon Property
    public virtual List<User> Users { get; set; }
    public virtual ICollection<DueInvoice> DueInvoices { get; set; } 

}
``` 


2.User Class:
```
public class User
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
    public virtual List<Message> Messages { get; set; }
}
```

3.Dues and invoices:
```
public class DuesInvoice
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
}
```
4.Message:

```
 public int Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime DateSent { get; set; }

    // Foreign Key
    public int UserId { get; set; }

    // Navigasyon Property
    public User User { get; set; }
```

5.Role:

```
 public string RoleName { get; set; }

    // Navigasyon Property
    public virtual List<User> Users { get; set; }
``` 

Son olarak, veritabanı bağlantısını ve tabloları oluşturma işlemlerini gerçekleştirmek için DbContext sınıfını oluşturmalıyız. Burada FinalCaseDbContext sınıfı, DbContext sınıfını kalıtım alarak veritabanı bağlantısını sağlar ve DbSet özellikleri üzerinden tablolara erişim imkanı sunar.
Veritabanı bağlantısını yapılandırmak için proje dosyanızda Startup.cs dosyasını düzenledim.

``` 
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
PAckage Manager Console'ı açarak, ``` Add-Migration InitialCreate```  komutunu ardından ``` Update-Database```  komutunu çalıştırarak veritabanındaki tabloları oluşturdum. Bu işlemlerden sonra artık tablolarım bulunmaktadır.

## 
AutoMapper implementasyonu gerçekleştirdim. Schema projesi ekledim. Modellerimi orada tanımladım.
```
<ItemGroup>
		<PackageReference Include="AutoMapper" Version="11.0.0" />
	</ItemGroup>
```


Automapper Config'i oluşturdum. Profile dan türedi. burada mapping tanımlarını ekleyeceğim. Burada Requestve Response olarak dosyaları ekledim.

response  ve request gibi sınıflar, istemci ve sunucu arasındaki iletişimi düzenlemek, veri güvenliğini sağlamak ve kodun daha düzenli ve esnek olmasını sağlamak amacıyla kullanılırlar.

Request Classı : Bu sınıf, istemciden alınan verileri temsil etmek için kullanılır. Sadece talep edilen özelliklerin yer aldığı bir yapıdır. Diğer gereksiz özellikler bu sınıfta yer almaz.

Response classı: Bu sınıf, sunucudan istemciye gönderilecek verileri temsil eder. İstemcinin sadece görmesi gereken özellikleri içerir. Diğer gereksiz özellikler bu sınıfta yer almaz.

------Buraya istemci requst fotosu ekleyebilrisin!-----
![alt text](Sipay-Bootcamp-FinalCase\FinalCase\FinalCase\Assets\RequestResponse.png)


<img src="Sipay-Bootcamp-FinalCase\FinalCase\FinalCase\Assets\RequestResponse.png" width="auto">


Tüm classların response ve request sayfaları oluşturuldu.





```startap.cs dosyasına mapper config olarak ekledim.

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfig());
            });
            services.AddSingleton(config.CreateMapper());
```