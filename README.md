# 🍽️ ASP.NET Core & MongoDB Restoran Yönetim Sistemi

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat-square&logo=mongodb&logoColor=white)
![AutoMapper](https://img.shields.io/badge/AutoMapper-8A2BE2?style=flat-square&logo=nuget&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat-square&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat-square&logo=css3&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=flat-square&logo=bootstrap&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)

---

## 📖 Proje Hakkında

Bu proje, **ASP.NET Core** ve **MongoDB** kullanılarak geliştirilmiş kapsamlı bir **Full Stack Restoran Yönetim Sistemi**dir. Fiziksel olarak tek katmanlı bir yapıda olsa da **Clean Code** prensiplerine sadık kalınarak mantıksal katmanlara (Entities, DTOs, Services, Controllers) ayrılmıştır. Veri tutarlılığı ve kodun sürdürülebilirliği için **Repository Design Pattern** uygulanmıştır.

---

## 🏗️ Mimari ve Teknik Detaylar

| Kategori | Teknoloji / Kütüphane | Kullanım Amacı |
|---|---|---|
| **Framework** | ASP.NET Core 10.0 | Ana uygulama çatısı |
| **Veritabanı** | MongoDB | NoSQL veri depolama |
| **ORM / Desen** | Repository Pattern | Veri erişim soyutlaması |
| **Mapping** | AutoMapper | Entity ve DTO nesne eşlemeleri |
| **Admin Panel** | Custom Admin Template | Yönetim arayüzü |
| **Frontend** | HTML5, CSS3, Bootstrap | Kullanıcı arayüzü tasarımı |
| **JavaScript** | Vanilla JS / jQuery | İstemci tarafı etkileşimler |

### 🔧 Geliştirme Prensipleri

- **Repository Design Pattern:** Veritabanı işlemlerini soyutlayarak kod tekrarını önler ve test edilebilirliği artırır.
- **Service Layer:** Her varlık (Entity) için ayrı servisler (`ProductService`, `CategoryService`, `OrderService` vb.) yazılarak iş mantığı controller'dan ayrıştırılmıştır.
- **DTO (Data Transfer Objects):** `Result`, `Create`, `Update` ve `GetById` işlemleri için ayrı DTO'lar kullanılarak veri güvenliği ve esneklik sağlanmıştır.
- **AutoMapper:** Entity ↔ DTO dönüşümleri otomatik olarak `GeneralMapping` profili üzerinden yönetilmektedir.
- **Dependency Injection:** Bağımlılıklar yönetilerek gevşek bağlı, genişletilebilir bir yapı oluşturulmuştur.

---

## 📂 Klasör Yapısı

```
Mongo/
├── Controllers/          # HTTP isteklerini yöneten controller sınıfları
│   ├── ProductController.cs
│   ├── CategoryController.cs
│   ├── OrderController.cs
│   ├── AdminController.cs
│   ├── SeedController.cs
│   └── ...
├── Entities/             # MongoDB koleksiyonlarına karşılık gelen entity sınıfları
│   ├── Product.cs
│   ├── Category.cs
│   ├── Order.cs
│   └── ...
├── Dtos/                 # Veri Transfer Nesneleri (Create, Update, Result, GetById)
│   ├── ProductDto/
│   ├── CategoryDto/
│   ├── OrderDto/
│   └── ...
├── Service/              # Servis arayüzleri ve implementasyonları
├── Mapping/              # AutoMapper profilleri
│   └── GeneralMapping.cs
├── Models/               # Yardımcı model sınıfları
├── appsettings.json      # MongoDB bağlantı ve koleksiyon ayarları
└── wwwroot/              # Statik dosyalar (CSS, JS, şablonlar)
    ├── template/         # Kullanıcı arayüzü şablonu
    └── admintemplate/    # Admin panel şablonu
```

---

## 🌐 Kullanıcı Arayüzü (Önyüz)

Ziyaretçilere yönelik tek sayfalık bir yapıya sahip olan önyüz; Navbar, Feature, İstatistik, Hakkımızda, Video, Ürünler, Yorumlar, SSS, E-Bülten ve Footer bölümlerinden oluşmaktadır.

---

### 🏠 Anasayfa — Feature (Öne Çıkanlar) Bölümü

Sayfanın ilk bölümü. MongoDB'deki `Features` koleksiyonundan dinamik olarak çekilen başlık, açıklama ve buton bilgileri hero alanında gösterilir. Ziyaretçiye restoranın sunduğu en önemli avantajlar vurgulanır.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1900" height="876" alt="Image" src="https://github.com/user-attachments/assets/a73c71a5-5926-43b3-bf8b-e070c57538a1" />

---

### 📊 İstatistik Bölümü

Restoranın sayısal verilerini (mutlu müşteri, sunulan ürün, yıl deneyimi vb.) gösteren statik sayaç alanıdır. Sayfayı kaydırınca animasyonlu biçimde sayıların arttığı görülür.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1898" height="423" alt="Image" src="https://github.com/user-attachments/assets/9c1eccda-9684-4401-a3b6-301650c92021" />

---

### ℹ️ Hakkımızda — Bölüm 1

`AboutSection1` koleksiyonundan gelen verilerle restoranın hikayesi ve vizyonu anlatılır. Görsel + metin düzeniyle iki kolonlu bir yapı kullanılmıştır.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1570" height="796" alt="Image" src="https://github.com/user-attachments/assets/f1148c4d-90b0-4c5f-b143-f0947d672397" />

---

### ℹ️ Hakkımızda — Bölüm 2

`AboutSection2` koleksiyonundan gelen verilerle restoranın misyonu ya da ek tanıtım içerikleri sunulur. Bölüm 1 ile birlikte `#about` anker linkiyle erişilebilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1601" height="876" alt="Image" src="https://github.com/user-attachments/assets/bb512275-ec88-40e7-9f82-548348440e02" />

---

### 🎬 Video Tanıtım Bölümü

`StoryVideos` koleksiyonundan gelen video URL'i embed edilerek restoranın mutfak arkası veya tanıtım videosu gösterilir. Ziyaretçilere görsel bir deneyim sunar.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1768" height="725" alt="Image" src="https://github.com/user-attachments/assets/7ad20a3b-b1fb-4d7f-967b-cad0cc3eb58a" />

---

### 🍕 Ürünler (Menü) Bölümü

`Products` koleksiyonundaki tüm ürünler kategorileriyle birlikte kart düzeninde listelenir. Her kartta ürün görseli, adı, hazırlanma süresi, güncel fiyatı ve varsa eski fiyatı yer alır.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1538" height="842" alt="Image" src="https://github.com/user-attachments/assets/a8dc2afd-8e5d-44e6-8437-db0dbbcb44dc" />
<img width="1593" height="796" alt="Image" src="https://github.com/user-attachments/assets/3f9b1d01-8154-4da8-9400-157b866aaa64" />
<img width="1554" height="827" alt="Image" src="https://github.com/user-attachments/assets/bd5ac96b-cfe7-432e-a5b0-3832916da537" />
<img width="1523" height="822" alt="Image" src="https://github.com/user-attachments/assets/1aa8ca50-29a9-44ce-aec9-5e0414505e0a" />
<img width="1568" height="845" alt="Image" src="https://github.com/user-attachments/assets/2c01e8b5-697a-4560-be6a-98cd487ee4e1" />
<img width="1589" height="805" alt="Image" src="https://github.com/user-attachments/assets/3b746c83-5b44-48b6-ba2f-3ca6fddf9428" />
<img width="1593" height="829" alt="Image" src="https://github.com/user-attachments/assets/2c482463-c9ce-4542-88b1-6cc289cbf193" />
<img width="1534" height="817" alt="Image" src="https://github.com/user-attachments/assets/5eafc688-a89e-49d1-b196-b769735904e0" />

---

### 💬 Müşteri Yorumları (Testimonial)

`Testimonials` koleksiyonundan gelen müşteri yorum ve değerlendirmeleri slider ya da grid düzeninde gösterilir. Müşteri adı, yorumu ve varsa fotoğrafı içerir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1501" height="860" alt="Image" src="https://github.com/user-attachments/assets/b588b5a6-4d14-46a8-998f-804f17b76de5" />

---

### ❓ Sık Sorulan Sorular (SSS)

`SSSs` koleksiyonundaki soru-cevap çiftleri accordion yapısıyla listelenir. Ziyaretçiler sık sorulan soruları hızlıca bulabilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1481" height="781" alt="Image" src="https://github.com/user-attachments/assets/2d8814fe-ca16-4b60-b02d-71455b596435" />

---

### 📧 E-Bülten Aboneliği

Sayfanın alt kısmında yer alan abonelik formu. Kullanıcı e-posta adresini girerek `POST /Subscribe/CreateSubscribe` endpoint'ine istek atar ve `Subscribes` koleksiyonuna kaydedilir. İlk siparişte %25 indirim sunulan bir kampanya ile desteklenir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1558" height="800" alt="Image" src="https://github.com/user-attachments/assets/51760bd0-882b-4a82-ac3f-225c1402b804" />

---

### 🔻 Footer

`_DefaultFooterComponentPartial` ile yönetilen footer alanı; sosyal medya linkleri (`SocialMedias` koleksiyonu), iletişim bilgileri ve telif hakkı satırını içerir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<!-- ![Footer](screenshots/footer.png) -->

---

## 🔒 Yönetim Paneli (Admin)

Admin paneli `/Admin/Index` adresiyle erişilebilir olup sol taraftaki sidebar menüsü aracılığıyla tüm modüllere ulaşılır.

---

### 📊 Dashboard (İstatistikler)

Admin panelinin ana sayfası. MongoDB koleksiyonlarından anlık olarak çekilen özet veriler (toplam ürün sayısı, sipariş sayısı, abone sayısı vb.) kart widget'ları üzerinde gösterilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1906" height="872" alt="Image" src="https://github.com/user-attachments/assets/e2747b2e-9905-439d-b575-d9500e3e73ad" />

---

### 🍕 Ürün Yönetimi

`/Product/ProductList` — Tüm ürünler tablo halinde listelenir; kategori adı badge olarak, ürün görseli küçük resim (thumbnail) olarak görüntülenir. Her satırda **Sil** ve **Güncelle** butonları yer alır.

`/Product/CreateProduct` — Yeni ürün ekleme formu. Kategori seçimi `ViewBag.Categories` ile dropdown'dan yapılır; ürün adı, fiyat, eski fiyat, hazırlanma süresi ve görsel URL girilir.

`/Product/UpdateProduct/{id}` — Seçilen ürünün mevcut bilgileri forma doldurulur, güncelleme yapılır.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1509" height="836" alt="Image" src="https://github.com/user-attachments/assets/5487227f-8846-43c5-a538-e8aa266d56c8" />
<img width="1489" height="870" alt="Image" src="https://github.com/user-attachments/assets/aaee9934-2bd4-412c-834c-97ce40942bf0" />
<img width="448" height="874" alt="Image" src="https://github.com/user-attachments/assets/88a37282-5c24-4071-80e1-d5a2fbe95f1a" />

---

### 🗂️ Kategori Yönetimi

`/Category/CategoryList` — Tüm kategoriler tablo halinde listelenir. Her kategoride ad, açıklama ve ikon URL'i gösterilir.

`/Category/CreateCategory` & `/Category/UpdateCategory/{id}` — Yeni kategori ekleme ve güncelleme formları.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1501" height="799" alt="Image" src="https://github.com/user-attachments/assets/cb1d484d-0cbc-453e-9ea7-dbca97cb57a3" />
<img width="1483" height="534" alt="Image" src="https://github.com/user-attachments/assets/c41e6b0e-9a7f-4b6f-a012-58fdda9e22f0" />
<img width="1496" height="541" alt="Image" src="https://github.com/user-attachments/assets/ec2689d6-9282-417f-996a-7a0561c2e8ab" />

---

### 📦 Sipariş Yönetimi

`/Order/OrderList` — Gelen tüm siparişler listelenir. Müşteri adı ve telefonu, ürün adı, adet, toplam tutar, tarih ve durum bilgisi görüntülenir. Sipariş durumu `Beklemede / Onaylandı / İptal Edildi` olarak badge'lerle gösterilir.

`/Order/UpdateOrder/{id}` — Sipariş durumu ve bilgileri güncellenir.

`/Order/CreateOrder` — Admin tarafından manuel sipariş oluşturulabilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1524" height="524" alt="Image" src="https://github.com/user-attachments/assets/223425d3-c213-41bc-b365-5731c4fb522d" />
<img width="1532" height="770" alt="Image" src="https://github.com/user-attachments/assets/b297ea9b-1821-4824-a403-7320bc42634e" />
<img width="1501" height="749" alt="Image" src="https://github.com/user-attachments/assets/68a6100e-ff01-4832-94db-a95d7dcd6b10" />

---

### ℹ️ Hakkımızda Bölüm 1 & 2 Yönetimi

`/AboutSection1/AboutSection1List` ve `/AboutSection2/AboutSection2List` — Önyüzde gösterilen hakkımızda içeriklerinin (başlık, açıklama, görsel URL) yönetildiği listeleme sayfaları. Her iki bölüm için ayrı oluşturma ve güncelleme formları bulunur.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1533" height="367" alt="Image" src="https://github.com/user-attachments/assets/dc87add2-89c3-44c1-bf00-1ba3f8b8d8d9" />
<img width="1517" height="671" alt="Image" src="https://github.com/user-attachments/assets/b432b9e7-15ac-4620-afa4-1502f44904d2" />
<img width="1531" height="365" alt="Image" src="https://github.com/user-attachments/assets/925034de-c009-4ef4-9bd2-e37f7869fb54" />
<img width="1524" height="676" alt="Image" src="https://github.com/user-attachments/assets/8bfb6921-18cf-4646-b45f-cd2c463f1eae" />

---

### ⭐ Öne Çıkanlar (Feature) Yönetimi

`/Feature/FeatureList` — Önyüzdeki hero alanında gösterilen özellikler listelenir ve yönetilir. Başlık, alt başlık ve ikon bilgisi içerir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1530" height="455" alt="Image" src="https://github.com/user-attachments/assets/05e4b0c0-9d9e-432b-b8b1-c90f4d8d44a2" />
<img width="1524" height="641" alt="Image" src="https://github.com/user-attachments/assets/6f7b6d5b-0ad0-4e9d-8c62-de2ac98b73fb" />
<img width="1528" height="642" alt="Image" src="https://github.com/user-attachments/assets/c4f97c84-fdf3-4ebe-bb04-7e51bda2810c" />

---

### 💬 Müşteri Yorumları Yönetimi

`/Testimonial/TestimonialList` — Önyüzde gösterilen müşteri yorumları listelenir. Müşteri adı, yorum metni ve görsel URL yönetilebilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1534" height="659" alt="Image" src="https://github.com/user-attachments/assets/5386768a-4043-49f3-8b84-486edfdb7483" />
<img width="1186" height="645" alt="Image" src="https://github.com/user-attachments/assets/3a52c1ef-4fa0-4582-ac16-37eaa71ae139" />
<img width="1520" height="650" alt="Image" src="https://github.com/user-attachments/assets/dce96053-7ec3-44d5-9a4f-d249e43347db" />

---

### 🎬 Video Tanıtımları Yönetimi

`/StoryVideo/StoryVideoList` — Önyüzde oynayan tanıtım videolarının URL ve açıklama bilgileri yönetilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1390" height="370" alt="Image" src="https://github.com/user-attachments/assets/2787a1fe-fdd0-416d-9e9c-452449895262" />
<img width="1506" height="747" alt="Image" src="https://github.com/user-attachments/assets/cbc80bc5-505e-4d29-9e7c-9201b62967f7" />

---

### ❓ S.S.S. Yönetimi

`/SSS/SSSList` — Sık sorulan soruların soru ve cevap metinleri eklenir, güncellenir veya silinir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1511" height="721" alt="Image" src="https://github.com/user-attachments/assets/fb3d3a2e-285a-4e6a-a82b-92a1cf36dbad" />
<img width="468" height="465" alt="Image" src="https://github.com/user-attachments/assets/85a6158b-aef2-45d8-965a-e15fb944e943" />
<img width="1472" height="460" alt="Image" src="https://github.com/user-attachments/assets/196f586f-a8a0-4ba9-b667-b5d065f211da" />

---

### 📧 Bülten Aboneleri

`/Subscribe/SubscribeList` — Önyüzdeki abonelik formundan gelen e-posta adresleri listelenir. Aboneler yönetilebilir veya silinebilir.

> 📸 *Ekran görüntüsü buraya eklenecek*
<img width="1490" height="846" alt="Image" src="https://github.com/user-attachments/assets/413b99a6-5629-4e1c-8e8a-e5e2cbc54f68" />
<img width="735" height="322" alt="Image" src="https://github.com/user-attachments/assets/406ca04f-66f2-4743-b5b3-5b92fb61f5b2" />
<img width="595" height="334" alt="Image" src="https://github.com/user-attachments/assets/96623af5-630d-4f07-b318-4e67d98e4165" />

---

## 🗄️ MongoDB Koleksiyonları

| Koleksiyon | Açıklama |
|---|---|
| Products | Menü ürünleri |
| Categories | Ürün kategorileri |
| Orders | Siparişler |
| AboutLists | Hakkımızda liste öğeleri |
| AboutSection1 / 2 | Hakkımızda bölüm içerikleri |
| Features | Öne çıkanlar / hero bölümü |
| Testimonials | Müşteri yorumları |
| StoryVideos | Video tanıtımları |
| SSSs | Sık sorulan sorular |
| SocialMedias | Sosyal medya linkleri |
| Subscribes | E-bülten aboneleri |

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community) (yerel veya Atlas)

### Adımlar

1. **Repoyu klonlayın:**
   ```bash
   git clone https://github.com/KULLANICI_ADINIZ/REPO_ADINIZ.git
   cd REPO_ADINIZ
   ```

2. **`appsettings.json` dosyasını yapılandırın:**
   ```json
   {
     "DatabaseSettings": {
       "ConnectionString": "mongodb://127.0.0.1:27017/",
       "DatabaseName": "MongoDB"
     }
   }
   ```

3. **Projeyi çalıştırın:**
   ```bash
   dotnet run
   ```

4. **Seed verilerini yükleyin** (opsiyonel):
   Tarayıcıdan `/Seed` adresini ziyaret ederek örnek verileri oluşturabilirsiniz.

---

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core 10.0 MVC
- MongoDB Driver for .NET
- AutoMapper
- Bootstrap 5
- jQuery
- HTML5 / CSS3

---

## 📬 İletişim

Herhangi bir sorunuz veya öneriniz için benimle iletişime geçebilirsiniz.

> Bu proje eğitim amaçlı geliştirilmiştir.
