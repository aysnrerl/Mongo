using Microsoft.AspNetCore.Mvc;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Controllers
{
    public class SeedController : Controller
    {
        private readonly IMongoDatabase _database;

        public SeedController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
        }

        public async Task<IActionResult> SeedAll()
        {
            await _database.DropCollectionAsync("Categories");
            await _database.DropCollectionAsync("Products");
            await _database.DropCollectionAsync("Orders");

            await SeedCategories();
            await SeedProducts();
            await SeedOrders();
            return Content("✅ Tüm eski veriler temizlendi ve yeni örnek veriler başarıyla eklendi! Kategoriler, Ürünler ve Siparişler oluşturuldu.");
        }

        private async Task SeedCategories()
        {
            var collection = _database.GetCollection<Category>("Categories");
            var count = await collection.CountDocumentsAsync(_ => true);
            if (count > 0) return;

            var categories = new List<Category>
            {
                new Category { CategoryName = "Burgerler", Description = "El yapımı özel burgerler", IconUrl = "🍔" },
                new Category { CategoryName = "Pizzalar", Description = "İtalyan usulü fırın pizzalar", IconUrl = "🍕" },
                new Category { CategoryName = "Salatalar", Description = "Taze ve sağlıklı salatalar", IconUrl = "🥗" },
                new Category { CategoryName = "Tatlılar", Description = "Ev yapımı tatlılar ve pastalar", IconUrl = "🍰" },
                new Category { CategoryName = "İçecekler", Description = "Soğuk ve sıcak içecekler", IconUrl = "🥤" },
                new Category { CategoryName = "Makarnalar", Description = "İtalyan usulü makarna çeşitleri", IconUrl = "🍝" }
            };
            await collection.InsertManyAsync(categories);
        }

        private async Task SeedProducts()
        {
            var collection = _database.GetCollection<Product>("Products");
            var count = await collection.CountDocumentsAsync(_ => true);
            if (count > 0) return;

            var products = new List<Product>
            {
                // Burgerler
                new Product { ProductName = "Klasik Smash Burger", CategoryName = "Burgerler", TotalTime = 20, Price = 185, OldPrice = 210, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=500&h=350&fit=crop" },
                new Product { ProductName = "BBQ Bacon Burger", CategoryName = "Burgerler", TotalTime = 25, Price = 210, OldPrice = 240, ImageUrl = "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=500&h=350&fit=crop" },
                new Product { ProductName = "Truffle Mushroom Burger", CategoryName = "Burgerler", TotalTime = 30, Price = 245, OldPrice = 280, ImageUrl = "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?w=500&h=350&fit=crop" },

                // Pizzalar
                new Product { ProductName = "Margherita Pizza", CategoryName = "Pizzalar", TotalTime = 25, Price = 165, OldPrice = 190, ImageUrl = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=500&h=350&fit=crop" },
                new Product { ProductName = "Pepperoni Pizza", CategoryName = "Pizzalar", TotalTime = 25, Price = 195, OldPrice = 220, ImageUrl = "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=500&h=350&fit=crop" },
                new Product { ProductName = "Karışık Pizza", CategoryName = "Pizzalar", TotalTime = 30, Price = 225, OldPrice = 260, ImageUrl = "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?w=500&h=350&fit=crop" },

                // Salatalar
                new Product { ProductName = "Sezar Salata", CategoryName = "Salatalar", TotalTime = 10, Price = 120, OldPrice = 140, ImageUrl = "https://images.unsplash.com/photo-1546793665-c74683f339c1?w=500&h=350&fit=crop" },
                new Product { ProductName = "Akdeniz Salatası", CategoryName = "Salatalar", TotalTime = 10, Price = 110, OldPrice = 130, ImageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?w=500&h=350&fit=crop" },
                new Product { ProductName = "Ton Balıklı Salata", CategoryName = "Salatalar", TotalTime = 15, Price = 145, OldPrice = 165, ImageUrl = "https://images.unsplash.com/photo-1540420773420-3366772f4999?w=500&h=350&fit=crop" },

                // Tatlılar
                new Product { ProductName = "Çikolatalı Sufle", CategoryName = "Tatlılar", TotalTime = 20, Price = 95, OldPrice = 115, ImageUrl = "https://images.unsplash.com/photo-1541783245831-57d6fb0926d3?w=500&h=350&fit=crop" },
                new Product { ProductName = "Cheesecake", CategoryName = "Tatlılar", TotalTime = 15, Price = 110, OldPrice = 130, ImageUrl = "https://images.unsplash.com/photo-1567171466295-4afa63d45416?w=500&h=350&fit=crop" },
                new Product { ProductName = "Tiramisu", CategoryName = "Tatlılar", TotalTime = 10, Price = 105, OldPrice = 125, ImageUrl = "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?w=500&h=350&fit=crop" },

                // İçecekler
                new Product { ProductName = "Taze Limonata", CategoryName = "İçecekler", TotalTime = 5, Price = 55, OldPrice = 65, ImageUrl = "https://images.unsplash.com/photo-1621263764928-df1444c5e859?w=500&h=350&fit=crop" },
                new Product { ProductName = "Türk Kahvesi", CategoryName = "İçecekler", TotalTime = 10, Price = 45, OldPrice = 55, ImageUrl = "https://images.unsplash.com/photo-1514432324607-a09d9b4aefda?w=500&h=350&fit=crop" },
                new Product { ProductName = "Smoothie Bowl", CategoryName = "İçecekler", TotalTime = 10, Price = 85, OldPrice = 100, ImageUrl = "https://images.unsplash.com/photo-1502741224143-90386d7f8c82?w=500&h=350&fit=crop" },

                // Makarnalar
                new Product { ProductName = "Fettuccine Alfredo", CategoryName = "Makarnalar", TotalTime = 25, Price = 155, OldPrice = 180, ImageUrl = "https://images.unsplash.com/photo-1645112411341-6c4fd023714a?w=500&h=350&fit=crop" },
                new Product { ProductName = "Penne Arrabbiata", CategoryName = "Makarnalar", TotalTime = 20, Price = 140, OldPrice = 160, ImageUrl = "https://images.unsplash.com/photo-1563379926898-05f4575a45d8?w=500&h=350&fit=crop" },
                new Product { ProductName = "Bolonez Spagetti", CategoryName = "Makarnalar", TotalTime = 30, Price = 165, OldPrice = 190, ImageUrl = "https://images.unsplash.com/photo-1622973536968-3ead9e780960?w=500&h=350&fit=crop" }
            };
            await collection.InsertManyAsync(products);
        }

        private async Task SeedOrders()
        {
            var collection = _database.GetCollection<Order>("Orders");
            var count = await collection.CountDocumentsAsync(_ => true);
            if (count > 0) return;

            var orders = new List<Order>
            {
                new Order { CustomerName = "Ahmet Yılmaz", CustomerEmail = "ahmet@mail.com", Address = "Kadıköy, İstanbul", Phone = "0532 111 2233", ProductName = "Klasik Smash Burger", Quantity = 2, UnitPrice = 185, TotalPrice = 370, OrderDate = DateTime.Now.AddDays(-1), Status = "Teslim Edildi" },
                new Order { CustomerName = "Elif Demir", CustomerEmail = "elif@mail.com", Address = "Beşiktaş, İstanbul", Phone = "0544 222 3344", ProductName = "Margherita Pizza", Quantity = 1, UnitPrice = 165, TotalPrice = 165, OrderDate = DateTime.Now.AddDays(-1), Status = "Teslim Edildi" },
                new Order { CustomerName = "Mehmet Kaya", CustomerEmail = "mehmet@mail.com", Address = "Çankaya, Ankara", Phone = "0555 333 4455", ProductName = "Sezar Salata", Quantity = 1, UnitPrice = 120, TotalPrice = 120, OrderDate = DateTime.Now.AddHours(-18), Status = "Teslim Edildi" },
                new Order { CustomerName = "Zeynep Arslan", CustomerEmail = "zeynep@mail.com", Address = "Bornova, İzmir", Phone = "0533 444 5566", ProductName = "Çikolatalı Sufle", Quantity = 3, UnitPrice = 95, TotalPrice = 285, OrderDate = DateTime.Now.AddHours(-12), Status = "Teslim Edildi" },
                new Order { CustomerName = "Can Öztürk", CustomerEmail = "can@mail.com", Address = "Nilüfer, Bursa", Phone = "0542 555 6677", ProductName = "BBQ Bacon Burger", Quantity = 2, UnitPrice = 210, TotalPrice = 420, OrderDate = DateTime.Now.AddHours(-8), Status = "Teslim Edildi" },
                new Order { CustomerName = "Ayşe Çelik", CustomerEmail = "ayse@mail.com", Address = "Karşıyaka, İzmir", Phone = "0538 666 7788", ProductName = "Pepperoni Pizza", Quantity = 1, UnitPrice = 195, TotalPrice = 195, OrderDate = DateTime.Now.AddHours(-6), Status = "Hazırlanıyor" },
                new Order { CustomerName = "Burak Şahin", CustomerEmail = "burak@mail.com", Address = "Ataşehir, İstanbul", Phone = "0546 777 8899", ProductName = "Fettuccine Alfredo", Quantity = 1, UnitPrice = 155, TotalPrice = 155, OrderDate = DateTime.Now.AddHours(-5), Status = "Hazırlanıyor" },
                new Order { CustomerName = "Selin Koç", CustomerEmail = "selin@mail.com", Address = "Yenişehir, Mersin", Phone = "0531 888 9900", ProductName = "Taze Limonata", Quantity = 4, UnitPrice = 55, TotalPrice = 220, OrderDate = DateTime.Now.AddHours(-4), Status = "Hazırlanıyor" },
                new Order { CustomerName = "Emre Aydın", CustomerEmail = "emre@mail.com", Address = "Muratpaşa, Antalya", Phone = "0543 999 0011", ProductName = "Truffle Mushroom Burger", Quantity = 1, UnitPrice = 245, TotalPrice = 245, OrderDate = DateTime.Now.AddHours(-3), Status = "Beklemede" },
                new Order { CustomerName = "Derya Güneş", CustomerEmail = "derya@mail.com", Address = "Osmangazi, Bursa", Phone = "0537 000 1122", ProductName = "Cheesecake", Quantity = 2, UnitPrice = 110, TotalPrice = 220, OrderDate = DateTime.Now.AddHours(-2), Status = "Beklemede" },
                new Order { CustomerName = "Oğuz Yıldız", CustomerEmail = "oguz@mail.com", Address = "Üsküdar, İstanbul", Phone = "0545 111 2233", ProductName = "Karışık Pizza", Quantity = 1, UnitPrice = 225, TotalPrice = 225, OrderDate = DateTime.Now.AddHours(-2), Status = "Beklemede" },
                new Order { CustomerName = "İrem Aktaş", CustomerEmail = "irem@mail.com", Address = "Konak, İzmir", Phone = "0539 222 3344", ProductName = "Akdeniz Salatası", Quantity = 2, UnitPrice = 110, TotalPrice = 220, OrderDate = DateTime.Now.AddHours(-1), Status = "Beklemede" },
                new Order { CustomerName = "Tolga Erdoğan", CustomerEmail = "tolga@mail.com", Address = "Sarıyer, İstanbul", Phone = "0534 333 4455", ProductName = "Bolonez Spagetti", Quantity = 1, UnitPrice = 165, TotalPrice = 165, OrderDate = DateTime.Now.AddMinutes(-45), Status = "Beklemede" },
                new Order { CustomerName = "Ceren Polat", CustomerEmail = "ceren@mail.com", Address = "Keçiören, Ankara", Phone = "0541 444 5566", ProductName = "Türk Kahvesi", Quantity = 3, UnitPrice = 45, TotalPrice = 135, OrderDate = DateTime.Now.AddMinutes(-30), Status = "Beklemede" },
                new Order { CustomerName = "Murat Aksoy", CustomerEmail = "murat@mail.com", Address = "Maltepe, İstanbul", Phone = "0536 555 6677", ProductName = "Tiramisu", Quantity = 2, UnitPrice = 105, TotalPrice = 210, OrderDate = DateTime.Now.AddMinutes(-10), Status = "Beklemede" }
            };
            await collection.InsertManyAsync(orders);
        }
    }
}
