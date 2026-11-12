
# Sefa Subaşı Portfolio

ASP.NET Core MVC ve Entity Framework Core kullanılarak geliştirilmiş kişisel portfolyo web uygulaması.

Uygulama; kişisel bilgiler, yetenekler, deneyimler, projeler, eğitim bilgileri ve iletişim mesajlarının yönetilebildiği dinamik bir portfolyo sitesidir.

## 🚀 Kullanılan Teknolojiler

- .NET 10
- ASP.NET Core MVC
- Entity Framework Core 10
- Microsoft SQL Server
- Razor View Engine
- HTML5, CSS3 ve JavaScript
- Bootstrap
- SQL Server LocalDB

## ✨ Özellikler

### Ziyaretçi Sayfaları

- Kişisel tanıtım alanı
- Hakkımda bölümü
- Yetenekler
- Profesyonel deneyimler
- Projeler
- Eğitim bilgileri
- İletişim formu
- Responsive tasarım

### Admin Paneli

- Dashboard
- Hakkımda bilgilerini güncelleme
- Yetenek yönetimi
- Deneyim yönetimi
- Proje yönetimi
- Eğitim bilgileri yönetimi
- Gelen mesajları görüntüleme
- Tanıtım alanlarını güncelleme

## 📁 Proje Yapısı

```text
Sefa_Subasi_Portfolio/
├── Areas/
│   └── Admin/
│       ├── Controllers/
│       ├── Views/
│       └── Models/
├── Controllers/
├── DAL/
│   ├── Context/
│   └── Entities/
├── Views/
│   ├── Home/
│   └── Shared/
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── images/
│   └── lib/
├── appsettings.json
├── Program.cs
└── Sefa_Subasi_Portfolio.csproj
```

## ⚙️ Gereksinimler

- .NET 10 SDK
- Visual Studio 2026 veya üzeri
- SQL Server LocalDB
- Git

.NET SDK sürümünü kontrol etmek için:

```powershell
dotnet --version
```

## 📥 Kurulum

Projeyi klonlayın:

```powershell
git clone https://github.com/sefasubasi/Sefa_Subasi_Portfolio.git
cd Sefa_Subasi_Portfolio
dotnet restore
dotnet build
```

## 🗄️ Veritabanı Ayarları

Proje varsayılan olarak SQL Server LocalDB kullanır. Veritabanı yapılandırması `DAL/Context/PortfolioContext.cs` dosyasında bulunmaktadır.

Varsayılan veritabanı bilgileri:

```text
Server=(localdb)\MSSQLLocalDB
Database=NewPortfolio
Integrated Security=True
Trusted_Connection=True
```

Entity Framework migration kullanıyorsanız:

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

`dotnet ef` komutu yüklü değilse:

```powershell
dotnet tool install --global dotnet-ef
```

> Üretim ortamında bağlantı bilgilerini doğrudan kod içerisinde tutmak yerine `appsettings.json`, User Secrets veya ortam değişkenleri kullanın.

## ▶️ Projeyi Çalıştırma

```powershell
dotnet run
```

Uygulama çalıştıktan sonra terminalde gösterilen HTTPS adresini tarayıcıda açın. Visual Studio ile çalıştırmak için `Sefa_Subasi_Portfolio.slnx` dosyasını açıp `F5` veya `Ctrl + F5` tuşlarına basabilirsiniz.

## 🔐 Admin Paneli

Admin alanı, MVC Area yönlendirmesi ile aşağıdaki formatta çalışır:

```text
https://localhost:<port>/Admin/<Controller>/<Action>
```

Örnek:

```text
https://localhost:<port>/Admin/About/Index
```

> Üretim ortamında admin paneli için kimlik doğrulama ve yetkilendirme eklenmesi gerekir.

## 🧩 Veritabanı Entity'leri

- `About`
- `Skill`
- `SkillItem`
- `Experience`
- `Project`
- `ProjectTechnology`
- `Education`
- `Contact`
- `Message`
- `Feature`

## 🛠️ Geliştirme

Yeni bir özellik için branch oluşturabilirsiniz:

```powershell
git checkout -b feature/yeni-ozellik
```

Değişiklikleri test ettikten sonra:

```powershell
git add .
git commit -m "Yeni özellik eklendi"
git push origin feature/yeni-ozellik
```

 
