# Gerekli Tool'lar için kurulum Kurulum Klavuzu

- #### KeyCloak Docker Desktop Kurulum

- docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:22.0.3 start-dev

- Yukarıdaki kod çalıştırılır docker desktop'da image otomatik oluşacaktır.

- Sonrasında localhost:8080'den admin panele giriş yapılır

- Step1 göreslindeki gibi master realm içerisinde Client sekmesinden admin-cli client'ı seçilir.

- Step2 göreslindeki gibi admin-cli client'ı daki settings kısımından Client authentication On hale getirilir. Service accounts roles kutucuğu tiklenir.

- Step3 göreslindeki gibi Service accounts roles kısımından bütün roller eklenir.

- Step4 göreslindeki gibi Advanced kısımından alt tarafta bulunan Access Token Lifespan ayarını Expires 30 days şeklinde değiştirilip save işlemi yapılır.

- Step5 göreslindeki gibi Credentials kısımından yeni bir Client secret KEY oluşturulur ve kopyalanır.

- Step6 göreslindeki gibi projenin içinden appsettings.json daki "ClientSecretBodyValue": "" içeriğine kopyalanan Client secret KEY yazılır.


- #### REDIS Docker Desktop Kurulum

- docker run --name redis  -p 6379:6379  -d redis redis-server

- Yukarıdaki kodu çalıştırmak yeterli olacaktır. Dcoker Desktop'da image oluşacaktır.
  
- #### PostgreSQL Docker Desktop Kurulum

- docker run -e POSTGRES_PASSWORD="Numlock1234!!" -p 5432:5432 --name local-postgres postgres

- Yukarıdaki kodu çalıştırmak yeterli olacaktır. Dcoker Desktop'da image oluşacaktır.

