# Boyut Bilgisayar Mülakat Proje Dokümanı

- #### KeyCloak Docker Desktop Kurulum Klavuzu

- Step1) Bu kodu cmd de yönetici olarak çalıştırıyoruz docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:22.0.3 start-dev

- Step2) Kodun çalıştığı ve Docker Desktop'da ayağa kalktığından emin olunur.

- Step3) Sonrasında localhost:8080'den admin panele giriş yapılır.

- Step4) username = admin password = admin şeklinde giriş yapılır.

- Step5) Göreslindeki gibi sol üstten realm sekmesi açılır ve Create Realm butonuna basılır

- Step6) Kutucukta işaretlendiği gibi boyutRealm adında realm oluşturulur isimlendirmeler görseldeki gibi olmalıdır.

- Step7) Sol menüden Client sekmesine gidilir ve create client butonuna basılır.

- Step8) Görseldeki gibi isimlendirme aynı olmalıdır boyut_client adında bir client tanımlanır ve next butonuna basılır

- Step9) Bu sekmede Client authentication butonu açılır ve Service accounts role tiklenir.

- Step10) Client sekmesinden boyut_client'ın içine girilir Credentials bölümünden Client secret değeri **kopyalanır Bu secret'ı son Step olan 24'de nereye koyulması gerektiği söylenmiştir**

- Step11) Bu sekmede bir ayara gerek yok next butonuna basılır ve client oluşturulur

- Step12) Client oluşturulduktan sonra boyut_client içeriğine girilir ve Service accounts roles kısmına gidip Assign Role butonuna tıklanır.

- Step13) offline_access ve uma_authorization yetkileri verilip assign butonuna tıklanır.

- Step14) Bir daha aynı sekmeye girerek fliter by clients butonuna tıklanır.

- Step15) Burada listelenen tüm roller tiklenir name sekmesine basmak yeterlidir sonrasında assign butonuna tıklanır.

- Step16) Sol menüden Users sekmesine gelinir ve add user butonuna basılır.

- Step17) Görseldeki gibi admin admında bir kullanıcı oluşturulur ve create butonuna tıklanır. "Bu kullanıcı ana kullanıcıdır tüm işlemler bu kullanıcı üzerinden döner"

- Step18) Aynı yerden admin user'ının içine tıklanır ve Credentials bölümüne giderek Set Password butonuna basılır.

- Step19) Burada işaretli olan yerlere dikkat ederek password'u admin olarak ayarlanır ve Temporary seçeneği kaldırlır save butonuna basılır.

- Step20) Aynı yerden admin user'ının içinden Role mapping sekmesine gidilir ve assign role butonuna basılır.

- Step21) Buradan offline_access ve uma_authorization seçilip assign butonuna basılır.

- Step22) Yeniden assign butonuna tıklanır ve filter by clients butonuna tıklanır

- Step23) Burada yine aynı şekilde bütün roller admin için Assign edilir name kısmına basmamız yeterlidir sonrasında Assign butonuna basıp kaydedebiliriz

- Step24 SONSTEP) Step10'dan kopayalanan client secret değeri resimdeki gibi appsettings.json içeriinse yazılır. ve doğruluğu kontrol edilir.

**Geri kalan ayarlar aynı olduğu için KeyCloak kurulumumuz hazır artık /api/User/create API'sine istek atılıp yeni kullanıcı oluşturulabilir.

- #### REDIS Docker Desktop Kurulum Klavuzu

- docker run --name redis  -p 6379:6379  -d redis redis-server

- Yukarıdaki kodu çalıştırmak yeterli olacaktır. Dcoker Desktop'da image oluşacaktır.

- #### PostgreSQL Docker Desktop Kurulum  Klavuzu

- docker run -e POSTGRES_PASSWORD="Numlock1234!!" -p 5432:5432 --name local-postgres postgres

- Yukarıdaki kodu çalıştırmak yeterli olacaktır. Dcoker Desktop'da image oluşacaktır.

