# Design Patterns

🔮 Eğitim , Asp.Net Core’un farklı sürümlerini (3.1, 5.0, 6.0, 7.0) ve çeşitli veri tabanlarını (MSSQL, PostgreSQL, MongoDB) kullanarak 11 farklı tasarım desenini pratiğe dökme fırsatı sunar.

## Kurs İçeriği ve Tasarım Desenleri

🔗 [Chain of Responsibility Design Pattern](#---chain-of-responsibility-design-pattern) : İsteklerin bir işleyici zinciri üzerinden yönlendirilmesini sağlar; her işleyici isteği işleyip işlemeyeceğine kendisi karar verir.

📈 [CQRS (Command Query Responsibility Segregation) Design Pattern](#---cqrs-command-query-responsibility-segregation) : Veri okuma ve yazma işlemlerini ayırarak performans ve ölçeklenebilirliği artırır.

📝 [Template Method Design Pattern](#---template-method-design-pattern) : Algoritmanın iskeletini belirlerken, bazı adımların alt sınıflar tarafından özelleştirilmesine izin verir.

👀 Observer Design Pattern : Bir nesnede değişiklik olduğunda bağlı nesnelerin otomatik güncellenmesini sağlar, nesneler arasındaki bağımlılığı azaltır.

🛠️ [Unit of Work Design Pattern](#%EF%B8%8F-unit-of-work-design-pattern) : Veritabanı işlemlerini bir işlemde toplar, hepsinin başarılı olması durumunda veritabanına yazar.

📂 [Repository Design Pattern](#---repository-design-pattern) : Veri erişimini soyutlayarak veri ile iş mantığını birbirinden ayırır.

🧩 Composite Design Pattern : "Bütün-parça" ilişkisini yönetir ve nesneleri aynı yapıda işler.

💬 Mediator Design Pattern : Nesneler arasındaki iletişimi merkezi bir aracı üzerinden gerçekleştirir.

🔄 [Iterator Design Pattern](#-iterator-tasarım-deseninin-amaç-ve-avantajları) : Koleksiyon elemanlarını gezmek için bağımsız bir yöntem sunar.

🧱 Facade Design Pattern : Karmaşık sistemlerin işlevlerini sadeleştirerek kolay bir arayüz sağlar.

🖌️ Decorator Design Pattern : Sınıflara dinamik olarak yeni işlevler ekler, mevcut sınıflara dokunmadan özellik katmayı mümkün kılar.

#️⃣ Kullanılan Kaynaklar

- https://refactoring.guru/design-patterns

- https://www.dofactory.com/net/design-patterns

## 🔗 - Chain of Responsibility Design Pattern

Chain of Responsibility (Sorumluluk Zinciri) tasarım deseni, isteklerin işleyici nesnelerden oluşan bir zincir boyunca iletilmesini sağlayan bir davranışsal tasarım desenidir. Bu desen, her işleyicinin isteği işleyip işleyemeyeceğine karar vermesine ve isteği gerektiğinde zincirdeki bir sonraki işleyiciye iletmesine olanak tanır. Bu yapı sayesinde, istekler bir zincir boyunca iletilir ve uygun işleyici tarafından ele alınır.

## Amaç

Chain of Responsibility deseni, isteklerin hiyerarşik bir şekilde işlenmesini sağlar. İşleyiciler, belirli bir işleme yeteneğine sahip nesnelerdir ve bu istek zincir boyunca dolaşarak uygun işleyiciye ulaşır.

## Temel Bileşenler

- **Handler (İşleyici):** Gelen isteği işleyen ya da bir sonraki işleyiciye ileten nesne.
- **ConcreteHandler (Somut İşleyici):** Gerçek işleme mantığını barındıran sınıflar.
- **Client (Müşteri):** İsteği başlatan ve zinciri harekete geçiren sınıf. Chain of Responsibility deseni, bir isteğin sıralı olarak işlenmesi gereken senaryolar için idealdir. Bu deseni aşağıdaki gibi durumlarda kullanabilirsiniz:
- **Kredi Onay Süreci:** Veznedar, şube müdürü, bölge müdürü gibi yetkililerin sırasıyla kredi talebini onaylaması.

## Örnek Proje: Kredi Onay Süreci

Bir bankanın kredi onay sürecini simüle eden örnek senaryoda, müşterinin talep ettiği kredi tutarına göre işlem yetkisi olan kişilere sırasıyla başvurulur:

1. Müşteri 1.250.000 TL kredi talep eder.
2. Veznedar, limiti 50.000 TL olduğu için bu talebi işleyemez ve bir üst seviyeye, şube müdür yardımcısına iletir.
3. Şube müdür yardımcısı 150.000 TL limiti aşan talebi işleyemez, bu nedenle talebi şube müdürüne iletir.
4. Şube müdürü, limiti 150.000 TL'yi aştığı için işleyemez ve talebi bölge müdürüne yönlendirir.
5. Bölge müdürü, maksimum limiti 1.600.000 TL olduğu için bu isteği onaylar ve işlem tamamlanır.
 
Bu senaryoda her işleyici, talebi ya işleyip onaylar ya da bir üst yetkiliye iletir. Bu yapı, sistemin esnek ve genişletilebilir olmasını sağlar.

## Avantajlar

- **Esneklik:** Yeni işleyiciler zincire kolayca eklenebilir veya çıkartılabilir.

- **Bağımlılığı Azaltır:** İstek gönderen nesne, hangi işleyicinin isteği işleyeceğini bilmek zorunda kalmaz.

- **Karmaşık İşlemleri Düzenler:** Çok adımlı ve hiyerarşik işlemleri yönetmek için ideal bir yapıdır.


## 📈 - CQRS (Command Query Responsibility Segregation)

CQRS (Command Query Responsibility Segregation), yazılım uygulamalarında veri okuma ve yazma işlemlerini ayrı sorumluluklarla yönetmeyi sağlayan bir tasarım desenidir. Bu sayede uygulama performansı, ölçeklenebilirliği ve sürdürülebilirliği artırılabilir.

## ⚫ CQRS Deseninin Temel Bileşenleri

1. **Commands (Komutlar)**: Uygulamanın durumunu değiştiren işlemlerden sorumludur. Veri ekleme, güncelleme veya silme işlemlerini içerir. Commands, geriye veri döndürmez; yalnızca işlem sonucunu bildirir.

2. **Queries (Sorgular)**: Sistemin durumunu değiştirmeden veri okuma işlemlerini yönetir. Queries yalnızca belirtilen veri modelini döner ve veriyi değiştirmez.

## ⚫ CQRS Kullanım Senaryoları

- Yüksek veri trafiği olan sistemlerde performans artırımı.
  
- Kompleks iş kuralları veya sık değişen iş kuralları.
  
- Hata toleransının yüksek olduğu sistemler: Bir serviste hata oluştuğunda diğer servislerin etkilenmemesi gerektiğinde.

## ⚫ Örnek: CQRS Yapısı

Bu örnek, Kullanıcı Yönetimi uygulaması için CQRS'nin temel yapısını gösterir.

### Komut: Kullanıcı Ekleme

Kullanıcı eklemek, sistemin durumunu değiştirdiği için Command olarak ele alınır. Bu işlemde:

* Command: Kullanıcı bilgilerini (Ad, Soyad, E-posta) içerir.
* Command Handler: Kullanıcıyı veritabanına ekler.
* Result: Geriye işlem sonucu döner, veri döndürülmez.

### Sorgu: Kullanıcı Bilgisi Getirme

Kullanıcı bilgisi almak, sistemin durumunu değiştirmediği için Query olarak ele alınır. Bu işlemde:

1. **Query**: Kullanıcı ID’sini içerir.
2. **Query Handler**: Kullanıcı bilgisini veritabanından getirir.
3. **Result**: Kullanıcı verisi döner, herhangi bir değişiklik yapılmaz.
   
## ⚫ CQRS'nin Avantajları

- **Performans ve Ölçeklenebilirlik:** Yazma ve okuma işlemlerini ayırarak her işlemi ayrı optimize etme imkanı sağlar.
- **Sürdürülebilirlik:** Her bir model kendi sorumluluğunu ele aldığı için daha modüler bir yapı oluşturur.
- **Deneyim Odaklı Tasarım:** Komut ve sorgu işlemleri, bağımsız olarak en uygun araç ve tekniklerle ele alınabilir.
  
## ⚫ Sonuç

CQRS, karmaşık veri yönetimi gereksinimlerini olan projelerde oldukça etkilidir. Ancak, bu tasarım deseni küçük projeler için gereksiz karmaşıklık yaratabileceğinden, büyük ve karmaşık projelerde tercih edilmelidir.


## 📝 - Template Method Design Pattern

Template Method, bir algoritmanın veya sürecin genel yapısını belirleyen, ancak bazı adımların alt sınıflar tarafından özelleştirilmesine izin veren bir davranışsal tasarım desenidir. Bu desen, abstract bir sınıf (şablon sınıf) ve ona bağlı bir veya birden fazla concrete sınıf (somut sınıf) ile uygulanır.

## 🔸 Template Method Deseninin Temel Bileşenleri

1. **Abstract Class (Şablon Sınıf)** : Sürecin genel akışını tanımlar ve sırasını belirler. Bazı adımlar abstract (soyut) metotlar olarak belirtilir, bu metotların implementasyonu alt sınıflara bırakılır.

2. **Concrete Class (Somut Sınıflar)** : Şablon sınıfta tanımlanan abstract metotları kendi ihtiyaçlarına göre özelleştirir. Böylece her alt sınıf aynı genel akışa bağlı kalırken kendine has detayları uygulayabilir.

## 🔸 Template Method Kullanım Senaryoları

* Bir algoritmanın temel yapısı sabittir, ancak bazı adımların alt sınıflar tarafından farklı şekillerde uygulanması gerekiyorsa.

* Kod tekrarını azaltmak ve ortak işlemleri merkezi bir sınıfta toplamak istendiğinde.

* Belirli bir süreç için temel yapıyı koruyup, detayları alt sınıflara bırakmak isteniyorsa.

## 🔸 Örnek: Alışveriş Sepetinde Ödeme Süreci

Bu örnekte, alışveriş sepetindeki ürünlerin satın alma süreci için Template Method deseni kullanacağız. Süreç her ürün için dört temel adımdan oluşur:

1. **Başlangıç**: İşlemin başlatılması.
2. **Ürün Seçimi**: Ürünün kullanıcı tarafından seçilmesi.
3. **Ödeme**: Ödeme işleminin yapılması.
4. **Bitiş**: İşlemin tamamlanması.

Örneğimizde televizyon ve buzdolabı satın alma işlemleri aynı akışa sahip olacak; ancak her bir ürünün seçim ve ödeme adımları farklılık gösterecek.

## 🔸 Örnek Akış

### Şablon Sınıf: ShoppingProcess

Bu sınıf, satın alma sürecinin adımlarını ve sırasını belirler. Ürün Seçimi ve Ödeme adımları soyut olarak tanımlanır, böylece her ürün için bu adımlar alt sınıflarda özelleştirilebilir.

### Alt Sınıf: TVPurchase

Televizyon satın alma süreci, ShoppingProcess şablon sınıfını temel alır, ancak Ürün Seçimi ve Ödeme adımlarını televizyon için özelleştirir.

### Alt Sınıf: RefrigeratorPurchase

Buzdolabı satın alma süreci de ShoppingProcess şablon sınıfını temel alır ve bu adımları buzdolabı için özelleştirir.

## 🔸 Template Method Deseninin Avantajları

**Kod Tekrarını Azaltma**: Ortak adımlar bir yerde toplanarak kod tekrarı azaltılır.

**Modülerlik ve Sürdürülebilirlik**: Farklı ürünlerin kendi özel süreç adımlarını tanımlaması sağlanır, bu da her alt sınıfın yalnızca kendi özelleştirilmiş adımlarını içermesine olanak tanır.

**Esneklik**: Temel akış sabit kalırken, her ürün için süreç adımları farklılaştırılabilir.

## 🔸 Sonuç

Template Method deseni, algoritmanın veya sürecin genel yapısını koruyarak, alt sınıfların yalnızca değişen veya spesifik adımları uyarlamasını sağlar. Bu desen, özellikle aynı sürecin farklı detaylar gerektirdiği durumlarda esneklik ve kod temizliği sağlar.


## 🛠️ Unit of Work Design Pattern

**Unit of Work Design Pattern**, veri tabanı işlemlerini bir araya toplayarak tek bir işlem (transaction) olarak yönetilmesini sağlayan bir davranışsal tasarım desenidir. Bu desen, tüm işlemlerin başarılı olması durumunda veritabanına yazılmasını, aksi takdirde hiçbir işlemin gerçekleştirilmemesini sağlar.

## 🔺 Unit of Work Tasarım Deseni’nin Temel Bileşenleri

- **Unit of Work (Çalışma Birimi)**: Veritabanı işlemlerini koordine eden ana sınıftır. İşlemleri gruplar, sıraya koyar ve başarılı bir şekilde tamamlanmalarını sağlar. Tüm işlemler tek bir transaction altında gerçekleştirilir, bu sayede işlemlerin güvenliği sağlanır.

- **Repository (Depo)**: Veritabanı işlemleri için kullanılan özel sınıflardır. Her veri tabanı nesnesi için bir repository sınıfı bulunabilir. Bu sınıflar, veritabanına erişim işlemlerini ve sorguları gerçekleştirir. Repository Pattern ile uyumlu çalışır ve veri tabanına erişimle ilgili tüm işlemleri içerir.

- **Entity (Varlık)**: Veritabanındaki tablolara karşılık gelen sınıflardır. Bu nesneler Repository sınıfları aracılığıyla CRUD (Create, Read, Update, Delete) işlemlerinde kullanılır.

## 🔺 Unit of Work Tasarım Deseni’nin Amaçları

1. **Veritabanı İşlemlerini Gruplama**: Tüm işlemleri bir araya toplayarak tek bir iş birimi olarak ele alır. Böylece işlemler daha kolay yönetilir ve koordine edilir.

2. **İşlemlerin Sırasını Belirleme**: İşlemlerin belirli bir sıra ile gerçekleşmesini sağlar. Bu sıraya göre veritabanı üzerinde gerekli güncellemeleri yapar.

3. **Tutarlılığı Sağlama**: Veritabanı işlemleri sırasında bir hata oluşursa, tüm işlemler geri alınır. Bu sayede veritabanının tutarlılığı korunmuş olur.

4. **Tekrar Kullanılabilirlik**: Daha modüler ve yeniden kullanılabilir bir yapı sağlar. Veritabanı işlemleri tek bir yapı altında toplandığından, kodun bakımı daha kolay hale gelir.

## 🔺 Kullanım Alanları

Unit of Work tasarım deseni, özellikle büyük ve karmaşık veri tabanına sahip uygulamalarda sıkça kullanılır. Örneğin:

- **E-Ticaret Siteleri**: Yoğun veri işlemlerinin bulunduğu ve işlemlerin bir bütün olarak yapılması gereken sistemlerde.

- **Finansal Uygulamalar**: Farklı işlemlerin toplu şekilde gerçekleştiği ve hata durumunda geri alınması gereken uygulamalarda.

## 🔺 Unit of Work Tasarım Deseni’nin Sağladığı Avantajlar

- **Performans**: Veritabanı işlemleri toplu halde gerçekleştirildiğinden maliyetleri düşürür ve performansı artırır.

- **Bakım Kolaylığı**: Tüm veri tabanı işlemleri tek bir yapı içinde toplandığı için bakımı ve genişletilmesi daha kolaydır.

- **Güvenlik ve Tutarlılık**: Hata durumunda tüm işlemleri geri alarak veri tabanının güvenliğini ve tutarlılığını sağlar.

## 🔺  Örnek Senaryo: E-Ticaret Sipariş İşlemleri

Bu senaryoda, bir e-ticaret uygulamasında bir sipariş süreci ele alınır. Bir siparişin başarılı bir şekilde kaydedilmesi, envanterin güncellenmesi ve kullanıcıya bildirim gönderilmesi gerekmektedir. Eğer bu işlemlerden herhangi birinde hata oluşursa, tüm işlemler geri alınmalıdır.

Akış:

1. Sipariş oluşturulur ve işleme alınır.
2. Ürün envanteri güncellenir.
3. Kullanıcıya sipariş bilgisi gönderilir.
4. Eğer tüm işlemler başarılı ise, transaction tamamlanır.
5. Bir hata durumunda ise tüm işlemler geri alınır.

## 📂 - Repository Design Pattern

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

## 🔄 Iterator Design Pattern 

**Iterator Design Pattern**, bir koleksiyonun elemanlarını tek tek gezmek ve bu elemanlara koleksiyonun yapısından bağımsız olarak erişmek için bir yöntem sağlar. Bu desen, dolaşımı (iterasyonu) koleksiyon yapısından ayırarak istemci kodun koleksiyonun iç yapısıyla ilgilenmesini önler ve her türlü veri yapısında (liste, yığın, ağaç vb.) aynı arabirimle dolaşım sağlar.

## ⚪ Iterator Tasarım Deseni'nin Amaç ve Avantajları

### 1. Dolaşımı Koleksiyondan Ayırma

Iterator deseni, koleksiyonun elemanlarına sırayla erişim sağlamak için kullanılan işlemleri koleksiyon sınıfından ayırır. Bu, koleksiyon sınıfının dolaşım yöntemlerini barındırmak zorunda olmadan veriyi depolamaya odaklanmasını sağlar.

### 2.Koleksiyon Türünden Bağımsız Dolaşım

İstemci, koleksiyonun türünden bağımsız bir şekilde aynı arabirimle tüm elemanlara erişebilir. Böylece, koleksiyon üzerinde yapılan dolaşım işlemleri koleksiyonun iç yapısındaki değişikliklerden etkilenmez.

### 3. Çoklu Dolaşım Desteği

Iterator deseninde, aynı koleksiyon üzerinde birden fazla bağımsız dolaşım yapabilmek mümkündür. Her iterator nesnesi, mevcut pozisyon ve kalan eleman gibi dolaşımla ilgili detayları ayrı ayrı tutar.

##	⚪ Iterator Tasarım Deseni’nin Bileşenleri

+ **Iterator Interface (Iterator Arabirimi)**: Koleksiyon üzerindeki dolaşım işlevlerini tanımlar. Örneğin, bir sonraki elemana geçme, geçerli elemana erişme, koleksiyonun sonuna gelip gelinmediğini kontrol etme gibi işlemleri içerir.

+ **Concrete Iterator (Somut Iterator)**: Iterator arayüzünü uygular ve belirli bir koleksiyon üzerinde dolaşım işlemini gerçekleştirir. Her koleksiyon türü için özel bir Concrete Iterator sınıfı olabilir.

+ **Collection Interface (Koleksiyon Arabirimi)**: Koleksiyonlar için ortak bir arayüzdür ve iterator nesnelerini oluşturmak için bir yöntem sağlar.

+ **Concrete Collection (Somut Koleksiyon)**: Koleksiyon arayüzünü uygular ve koleksiyonun gerçek yapısını yönetir. Elemanlara erişmek için bir iterator nesnesi döndürür.

##	⚪ Iterator Tasarım Desenini Kullanma Durumları

1. **Farklı Koleksiyon Yapılarıyla Çalışma Gereksinimi**: Örneğin, bir liste, ağaç veya graf gibi veri yapılarının elemanlarını tek tip bir dolaşım yöntemiyle gezmek istendiğinde.

2. **Dolaşım Sırasının Kontrol Altında Olması Gereken Durumlar**: Bir koleksiyonun tüm elemanları üzerinden sırayla, rastgele veya özel bir sıra ile geçmek gerektiğinde.

3. **Koleksiyonun İç Yapısının Gizlenmesi İstendiğinde**: Koleksiyonların iç yapısının dış koddan gizlenmesi, istemci kodunun koleksiyonun veri depolama yöntemiyle ilgilenmeden dolaşım yapabilmesini sağlar.

## ⚪ Iterator Tasarım Deseni Çalışma Akışı

* **Iterator Arayüzünün Tanımlanması**: Bu arayüz, dolaşım için temel işlevleri içerir.

* **Somut Iterator Sınıfının Oluşturulması:** Bu sınıf, belirli bir koleksiyon için dolaşımı gerçekleştirir.

* **Koleksiyon Arayüzünün Tanımlanması:** Koleksiyonlar için ortak işlevler sunar ve iterator nesneleri döndürür.

* **Somut Koleksiyon Sınıflarının Oluşturulması:** Bu sınıflar, koleksiyon arayüzünü uygulayarak elemanları yönetir ve iterator nesneleri sağlar.

## ⚪ Örnek Kullanım Senaryosu

Bir belge yönetim sistemini düşünelim. Bu sistemde belgeler farklı veri yapılarında (listeler, ağaçlar veya graf yapıları gibi) saklanabilir. Kullanıcının tüm belge öğelerini dolaşmak istemesi durumunda, belge koleksiyonlarının türüne göre farklı dolaşım yöntemleri gerekebilir. Iterator deseni sayesinde, kullanıcı aynı arabirimle tüm belgeleri dolaşabilir ve her belge koleksiyonu kendi iterator sınıfını kullanarak özel dolaşım mantığını uygular.

## ⚪ Iterator Design Pattern’in Avantajları

- **Modülerlik:** Koleksiyon yapısından bağımsız dolaşım sağlar, bu da kodu daha esnek ve modüler hale getirir.

- **Gizlilik ve Esneklik:** Koleksiyonun iç yapısı gizlendiği için, istemci koda koleksiyon türü hakkında bilgi vermeden dolaşım sağlanabilir.

- **Bağımsız ve Esnek Dolaşım:** Aynı koleksiyon üzerinde birden fazla bağımsız iterator çalıştırılabilir ve her iterator nesnesi kendi konumunu saklar.

Iterator Design Pattern, koleksiyonun iç yapısını istemci koddan gizleyerek dolaşımı bağımsız hale getirir ve özellikle farklı koleksiyon türleriyle çalışırken kodun temiz, sürdürülebilir ve anlaşılır olmasını sağlar.
