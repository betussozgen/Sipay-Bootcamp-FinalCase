# Daire Yönetim Sistemi Projesi

Bu proje, bir apartman veya konut sitesinin aidat ve fatura yönetimini kolaylaştırmak için tasarlanmış bir web tabanlı uygulamadır. Projede, yönetici ve kullanıcı rolleri arasında farklı yeteneklere sahip iki tip kullanıcı bulunmaktadır.

## Özellikler

- **Yönetici (Admin) Kullanıcısı:**
  - Daire bilgilerini ekleyebilir, düzenleyebilir ve silebilir.
  - İkamet eden kullanıcıları ekleyebilir ve yönetebilir.
  - Daire başına aidat ve fatura bilgilerini yönetebilir.
  - Gelen ödemeleri görüntüleyebilir.
  - Gelen mesajları görüntüleyebilir ve yönetebilir.
  - Borç-alacak listesini aylık olarak görüntüleyebilir.
  - Kullanıcı ve daire bilgilerini listeleyebilir, düzenleyebilir ve silebilir.
  - Fatura ödemeyen kişilere otomatik e-posta gönderilebilir.

- **Kullanıcı Kullanıcısı:**
  - Atanan aidat ve fatura bilgilerini görüntüleyebilir.
  - Sadece kredi kartı ile ödeme yapabilir.
  - Yöneticiye mesaj gönderebilir.

## Kullanılan Teknolojiler

- Backend: .NET
- Veritabanı: MS SQL Server / PostgreSQL
- Ödeme Servisi: Ayrı bir servis kullanılacak (örneğin, banka entegrasyonu)

## Klasör Yapısı

- **FinalCase**: Ana proje klasörü.
- **FinalCase.Base**: Temel sınıfların ve modellerin bulunduğu kütüphane.
- **FinalCase.DataAccess**: Veritabanı erişimi ve ORM (Object-Relational Mapping) işlemlerinin yapıldığı kütüphane.
- **FinalCase.Operation**: İş mantığı ve servislerin bulunduğu kütüphane.
- **FinalCase.Schema**: Veri yapıları ve transfer nesnelerinin (DTOs) bulunduğu kütüphane.


## Kurulum ve Kullanım

1. Bu projeyi klonlayın veya indirin.
2. Gerekli bağımlılıkları yüklemek için `dotnet restore` komutunu çalıştırın.
3. Veritabanını oluşturmak için `dotnet ef database update` komutunu kullanın.
4. Projenizi çalıştırmak için `dotnet run` komutunu kullanın.











