# MultiShop Projesi

MultiShop, gerçek bir dünya e-ticaret senaryosunu mikroservis mimarisi ile geliştiren ve birçok modern teknolojiyi entegre eden bir projedir. Bu projede, güçlü bir API geliştirme süreci, veritabanı yönetimi, güvenlik ve daha birçok önemli konu ele alınmıştır.

## İçindekiler
- [Genel Bakış](#genel-bakış)
- [Mimari ve Tasarım Desenleri](#mimari-ve-tasarım-desenleri)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Proje Detayları](#proje-detayları)


---

## Genel Bakış

MultiShop, **ASP.NET Core**, **Docker**, **Redis**, **MongoDB**, **PostgreSQL**, **MSSQL** ve diğer modern teknolojilerle inşa edilmiş bir mikroservis tabanlı e-ticaret platformudur. Her biri bağımsız olarak geliştirilmiş ve dağıtılmış olan mikroservisler, bir araya gelerek tam işlevsel bir e-ticaret senaryosu sunar.


---

## Mimari ve Tasarım Desenleri

MultiShop projesi, modern yazılım mimarisi ve tasarım desenleriyle oluşturulmuştur:
- **Onion Architecture**: Uygulamanın iç işleyişi ile dış dünyayı birbirinden ayırarak, bağımlılıkları yönetir ve test edilebilirliği artırır.
- **CQRS (Command Query Responsibility Segregation)**: Veri yazma (Command) ve okuma (Query) işlemleri arasındaki ayrım, performansı ve ölçeklenebilirliği artırır.
- **Mediator Design Pattern**: Mikroservisler arasındaki iletişimi kolaylaştırmak için kullanılır.
- **Repository Design Pattern**: Veri erişim katmanını soyutlayarak, veri manipülasyonlarını daha yönetilebilir hale getirir.

Bu desenler, projeyi daha sürdürülebilir, esnek ve ölçeklenebilir kılar.

---

## Kullanılan Teknolojiler

- **Redis**: Veritabanı önbelleklemesi ve oturum yönetimi için kullanılmıştır.
- **Dapper**: Performans odaklı veri erişim katmanı olarak kullanılmıştır.
- **Docker**: Her mikroservis, bağımsız olarak Docker konteynerlarında çalışacak şekilde yapılandırılmıştır. Bu, servislerin dağıtımını ve yönetimini kolaylaştırır.
- **MongoDB**: NoSQL veritabanı olarak kullanılmış, esnek veri modelleme gereksinimlerini karşılar.
- **PostgreSQL ve MSSQL**: SQL tabanlı veritabanları, ilişkisel veri yönetimi için kullanılmıştır.
- **Identity Server**: Kullanıcı doğrulama ve yetkilendirme işlemleri için kullanılmıştır.
- **Ocelot API Gateway**: Mikroservislerin yönetilmesi ve yönlendirilmesi için API Gateway olarak kullanılır.
- **Swagger**: API dökümantasyonu sağlamak için kullanılmıştır.
- **SignalR**: Gerçek zamanlı iletişim için kullanılmıştır.
- **Ajax**: Asenkron veri alışverişi sağlamak için kullanılmıştır.
- **Postman**: API testlerini gerçekleştirmek için kullanılmıştır.

---

## Proje Detayları

MultiShop projesi, aşağıdaki özellikleriyle dikkat çeker:
- **Gerçek E-Ticaret Senaryosu**: Kullanıcılar için alışveriş, ödeme, ürün yönetimi gibi temel e-ticaret işlevleri içerir.
- **Mikroservis Yapısı**: Proje, her bir işlevin ayrı bir mikroserviste tutulduğu bir yapıyı takip eder. Bu mikroservisler, bağımsız olarak geliştirilip dağıtılabilir.
- **Farklı Kullanıcı Rolleri**: Admin, misafir kullanıcı ve giriş yapmış kullanıcılar için farklı yetkilendirme senaryoları uygulanmıştır.
- **JWT ve OAuth 2.0**: Kimlik doğrulama ve yetkilendirme işlemleri için **JSON Web Token (JWT)** ve **OAuth 2.0** kullanılmıştır.

---
## Teşekkür

Udemy üzerinden sunduğu **"Asp.Net Core MultiShop Mikroservis E-Ticaret Kursu"** eğitimi ile mikroservis geliştirme ve modern teknolojileri derinlemesine öğrenmemize ve uygulama geliştirme süreçlerini daha verimli hale getirmeme olanak sağladığı için **Murat Yücedağ**'a teşekkür ederim.


