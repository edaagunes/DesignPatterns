# Design Patterns

🔮 Eğitim , Asp.Net Core’un farklı sürümlerini (3.1, 5.0, 6.0, 7.0) ve çeşitli veri tabanlarını (MSSQL, PostgreSQL, MongoDB) kullanarak 11 farklı tasarım desenini pratiğe dökme fırsatı sunar.

## Kurs İçeriği ve Tasarım Desenleri

🔗 Chain of Responsibility Design Pattern : İsteklerin bir işleyici zinciri üzerinden yönlendirilmesini sağlar; her işleyici isteği işleyip işlemeyeceğine kendisi karar verir.

📈 CQRS (Command Query Responsibility Segregation) Design Pattern : Veri okuma ve yazma işlemlerini ayırarak performans ve ölçeklenebilirliği artırır.

📝 Template Method Design Pattern : Algoritmanın iskeletini belirlerken, bazı adımların alt sınıflar tarafından özelleştirilmesine izin verir.

👀 Observer Design Pattern : Bir nesnede değişiklik olduğunda bağlı nesnelerin otomatik güncellenmesini sağlar, nesneler arasındaki bağımlılığı azaltır.

🛠️ Unit of Work Design Pattern : Veritabanı işlemlerini bir işlemde toplar, hepsinin başarılı olması durumunda veritabanına yazar.

📂 [Repository Design Pattern](#---repository-design-pattern) : Veri erişimini soyutlayarak veri ile iş mantığını birbirinden ayırır.

🧩 Composite Design Pattern : "Bütün-parça" ilişkisini yönetir ve nesneleri aynı yapıda işler.

💬 Mediator Design Pattern : Nesneler arasındaki iletişimi merkezi bir aracı üzerinden gerçekleştirir.

🔄 Iterator Design Pattern : Koleksiyon elemanlarını gezmek için bağımsız bir yöntem sunar.

🧱 Facade Design Pattern : Karmaşık sistemlerin işlevlerini sadeleştirerek kolay bir arayüz sağlar.

🖌️ Decorator Design Pattern : Sınıflara dinamik olarak yeni işlevler ekler, mevcut sınıflara dokunmadan özellik katmayı mümkün kılar.

#️⃣ Kullanılan Kaynaklar

- https://refactoring.guru/design-patterns

- https://www.dofactory.com/net/design-patterns

### 📂 - Repository Design Pattern

Repository Design Pattern, yazılım geliştirme süreçlerinde veri erişimini düzenlemek ve yönetmek amacıyla kullanılan bir tasarım desenidir. Bu desenin temel amacı, veri tabanı işlemlerini soyutlamak, veri erişim işlemlerini daha modüler hale getirmek ve veri erişimini iş mantığından ayırmaktır. Repository deseni, veritabanıyla ilgili tüm işlemleri tek bir merkezi yapı altında toplar ve veri erişimini kolaylaştırır.

## 🔹 Repository Tasarım Deseni’nin Amacı ve Avantajları

1. **Veri Erişimini Soyutlama ve İzolasyon**
   
Repository deseni, veri erişimini soyutlayarak uygulama kodunu veritabanı detaylarından ayırır. Bu sayede, iş mantığını yazarken veri tabanı ile ilgili işlemlerle uğraşmaya gerek kalmaz ve veri erişim kodları bağımsız hale gelir.

2. **Kodun Daha Bakımı Kolay Olması**
   
Veri erişim kodları tek bir yerde toplandığı için, veritabanında yapılan bir değişikliğin iş mantığına etkisi minimize edilir. Veritabanı yapısında bir değişiklik gerektiğinde yalnızca repository sınıflarında düzenleme yaparak ilgili işlemler güncellenebilir.

3. **Daha İyi Test Edilebilirlik**
Veri erişim işlemlerini soyutladığı için, iş mantığını test etmek istediğinizde veri tabanı detayları ile uğraşmanıza gerek kalmaz. Repository sınıflarını mock ederek veya sahte veri kaynaklarıyla çalıştırarak kolayca birim testi yapılabilir.

4. **Yeniden Kullanılabilirlik**
Veri erişim kodunu merkezi bir yere toplamak, farklı uygulama bölümlerinin aynı veri kaynaklarına erişimini sağlar. Bu, tekrar kullanılabilir kod yapısına olanak tanır ve genel kod kalitesini artırır.

## 🔹 Repository Tasarım Deseni’nin Bileşenleri

**Repository Interface (Depo Arayüzü)**: Veritabanı nesneleri için gerekli veri erişim işlemlerini tanımlar. Genellikle Add, Update, Delete, GetById, ve GetAll gibi temel CRUD işlemleri bu arayüzde yer alır.

**Concrete Repository (Somut Depo Sınıfı)**: Interface’de tanımlanan veri erişim işlemlerini gerçekleyen sınıftır. Veri tabanına erişimi sağlar ve interface’in gerektirdiği yöntemleri uygular.

**Entity (Varlık)**: Veritabanındaki tablolara karşılık gelen nesnelerdir. Bu nesneler, repository sınıfında yapılan veri işlemlerinde kullanılır.

**Service Layer (Hizmet Katmanı)**: İş mantığını temsil eden katmandır. Service Layer, repository sınıfını kullanarak veri erişim işlemlerini gerçekleştirir.

## 🔹 Repository Tasarım Deseni’nin Kullanım Alanları

**Büyük ve Karmaşık Uygulamalar**: Çok sayıda veri tabanı tablosu bulunan, veri işlemlerinin yoğun olduğu uygulamalarda.

**E-Ticaret Uygulamaları**: Müşteri, ürün, sipariş gibi çoklu veri kaynaklarının bulunduğu sistemlerde.

**Finansal Uygulamalar**: Finansal verilerin sık güncellenmesi gereken sistemlerde veri erişimini kolaylaştırır.

## 🔹 Repository Pattern’in Çalışma Akışı

**Veri Erişim İşlemlerinin Tanımlanması**: Repository arayüzü, CRUD işlemlerini tanımlar.

**Veritabanı İşlemlerinin Gerçeklenmesi**: Concrete Repository sınıfı, bu CRUD işlemlerini gerçekleştirir.

**İş Mantığı Katmanının Kullanması**: İş mantığı katmanı, Repository arayüzünü kullanarak veri işlemlerini gerçekleştirir ve veri erişim detaylarından izole edilir.

**Birden Fazla Uygulama Katmanında Kullanımı**: Repository sınıfları, farklı uygulama katmanları tarafından veri erişimi için kullanılabilir.

## 🔹 Repository Design Pattern Kullanmanın Avantajları

**Bakımı Kolaylaştırır**: Veri erişim kodları tek bir noktada toplandığı için bakım daha kolay hale gelir.

**Kodun Test Edilebilirliğini Artırır**: Mock sınıflarla veri tabanına ihtiyaç duymadan test yapılabilir.

**Kodun Modüler Yapıda Olmasını Sağlar**: Veri erişim ve iş mantığı ayrıldığı için kod daha düzenli hale gelir ve daha kolay genişletilebilir.

Repository Pattern, yazılım geliştirme süreçlerinde veri tabanı işlemlerini düzenleyerek kodun daha temiz, modüler ve test edilebilir olmasını sağlar.

