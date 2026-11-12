# Sefa Subaşı Portfolio

ASP.NET Core MVC ve Entity Framework Core kullanılarak geliştirilen dinamik kişisel portfolyo web uygulaması.

Uygulama; kişisel bilgilerin, yeteneklerin, profesyonel deneyimlerin, projelerin ve eğitim bilgilerinin yönetilebildiği, ziyaretçilere responsive bir arayüz sunan bir portfolyo sitesidir. Yönetim paneli üzerinden portfolyo içerikleri ve ziyaretçilerden gelen iletişim mesajları yönetilebilir.

## Kullanılan Teknolojiler

- **Platform:** .NET 10, ASP.NET Core MVC
- **ORM:** Entity Framework Core 10
- **Veritabanı:** Microsoft SQL Server, SQL Server LocalDB
- **View Engine:** Razor
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap

## Uygulama Ekran Görüntüleri

### Ziyaretçi Arayüzü

#### Ana Sayfa

![Ana Sayfa](docs/images/home-page.png)

#### Hakkımda ve Yetenekler

<p align="center">
  <img src="~/wwwroot/images/about-section.png" width="49%" alt="Hakkımda bölümü" />
  <img src="docs/images/skills-section.png" width="49%" alt="Yetenekler bölümü" />
</p>

#### Deneyimler ve Projeler

<p align="center">
  <img src="docs/images/experience-section.png" width="49%" alt="Deneyimler bölümü" />
  <img src="docs/images/projects-section.png" width="49%" alt="Projeler bölümü" />
</p>

#### Eğitim ve İletişim

<p align="center">
  <img src="docs/images/education-section.png" width="49%" alt="Eğitim bölümü" />
  <img src="docs/images/contact-section.png" width="49%" alt="İletişim bölümü" />
</p>

### Yönetim Paneli

#### Dashboard

![Admin Dashboard](docs/images/admin-dashboard.png)

Dashboard üzerinden mesaj istatistikleri, okunma oranları, proje ve deneyim dağılımı ile son mesajlar görüntülenebilir.

#### İçerik Yönetimi

<p align="center">
  <img src="docs/images/admin-entry.png" width="49%" alt="Giriş alanı yönetimi" />
  <img src="docs/images/admin-about.png" width="49%" alt="Hakkımda yönetimi" />
</p>

<p align="center">
  <img src="docs/images/admin-skills.png" width="49%" alt="Yetenek yönetimi" />
  <img src="docs/images/admin-experiences.png" width="49%" alt="Deneyim yönetimi" />
</p>

<p align="center">
  <img src="docs/images/admin-projects.png" width="49%" alt="Proje yönetimi" />
  <img src="docs/images/admin-education.png" width="49%" alt="Eğitim yönetimi" />
</p>

#### Mesaj Yönetimi ve Bildirimler

<p align="center">
  <img src="docs/images/admin-contact.png" width="49%" alt="İletişim mesajları" />
  <img src="docs/images/admin-messages-notifications.png" width="49%" alt="Gelen mesajlar ve bildirimler" />
</p>

## Özellikler

### Ziyaretçi Arayüzü

- Kişisel tanıtım ve hakkımda bölümü
- Yeteneklerin kategorilere göre listelenmesi
- Profesyonel deneyimlerin görüntülenmesi
- Projelerin ve ilişkili teknolojilerin listelenmesi
- Eğitim bilgilerinin görüntülenmesi
- İletişim formu
- Responsive tasarım

### Yönetim Paneli

- Dashboard ve özet istatistikler
- Giriş/karşılama alanı ve profil görseli yönetimi
- Hakkımda bilgilerinin güncellenmesi
- Yetenek kategorileri ve yeteneklerin yönetimi
- Deneyim kayıtları için CRUD işlemleri
- Projelerin ve proje teknolojilerinin yönetimi
- Eğitim kayıtları için CRUD işlemleri
- Gelen iletişim mesajlarının listelenmesi ve yönetimi
- Okunmamış mesaj bildirimleri

## Proje Yapısı

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

## Veritabanı Yapısı

Uygulamada Entity Framework Core ile SQL Server veritabanı kullanılmaktadır.

Tanımlı entity sınıfları:

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

## Gereksinimler

- .NET 10 SDK
- Visual Studio 2026 veya uyumlu bir .NET IDE
- SQL Server LocalDB
- Git

.NET SDK sürümünü kontrol etmek için:

```powershell
dotnet --version
```

## Kurulum

### 1. Depoyu klonlayın

```powershell
git clone https://github.com/sefasubasi/Sefa_Subasi_Portfolio.git
cd Sefa_Subasi_Portfolio
```

### 2. Bağımlılıkları yükleyin ve projeyi derleyin

```powershell
dotnet restore
dotnet build
```

## Veritabanı Yapılandırması

Proje varsayılan olarak SQL Server LocalDB kullanacak şekilde yapılandırılmıştır. Bağlantı ayarları `DAL/Context/PortfolioContext.cs` dosyasında bulunmaktadır.

Örnek bağlantı bilgisi:

```text
Server=(localdb)\MSSQLLocalDB;
Database=NewPortfolio;
Integrated Security=True;
Trusted_Connection=True;
```

Entity Framework Core CLI yüklü değilse:

```powershell
dotnet tool install --global dotnet-ef
```

Mevcut migration'ları veritabanına uygulamak için:

```powershell
dotnet ef database update
```

Projede henüz migration bulunmuyorsa ilk migration oluşturulabilir:

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> Not: İlk migration komutunu yalnızca projede mevcut migration yoksa çalıştırın. Üretim ortamında bağlantı bilgilerini kaynak kodda tutmak yerine User Secrets veya ortam değişkenleri gibi güvenli yapılandırma yöntemlerini kullanın.

## Uygulamayı Çalıştırma

```powershell
dotnet run
```

Uygulama çalıştıktan sonra terminalde görüntülenen HTTPS adresini tarayıcıda açın.

Visual Studio üzerinden çalıştırmak için `Sefa_Subasi_Portfolio.slnx` dosyasını açıp `F5` veya `Ctrl + F5` tuşlarını kullanabilirsiniz.

## Yönetim Paneli

Yönetim paneli ASP.NET Core MVC Area yapısı üzerinden çalışmaktadır.

Örnek adres:

```text
https://localhost:<port>/Admin/Dashboard/Index
```

> Güvenli bir canlı ortam için yönetim panelinde kimlik doğrulama ve rol/yetki kontrolleri yapılandırılmalıdır.

## Geliştirme

Yeni bir özellik için branch oluşturabilirsiniz:

```powershell
git checkout -b feature/yeni-ozellik
```

Değişiklikleri kaydetmek ve göndermek için:

```powershell
git add .
git commit -m "Yeni özellik eklendi"
git push origin feature/yeni-ozellik
```

## Geliştirici

**Sefa Subaşı**

- GitHub: [github.com/sefasubasi](https://github.com/sefasubasi)
- Proje Deposu: [Sefa_Subasi_Portfolio](https://github.com/sefasubasi/Sefa_Subasi_Portfolio)

---

Bu proje, kişisel çalışmalarımı, yazılım geliştirme deneyimimi ve teknik yetkinliklerimi sergilemek amacıyla geliştirilmiştir.
