# Boyut Bilgisayar Mülakat Proje Dokümanı

- #### Kullanılan kütüphaneler :  AutoMapper, Newtonsoft.Json, EntityFrameworkCore, DependencyInjection, JwtBearer, MediatR, KeyCloak, REDIS

- #### Kullanılan Design Patterler :  Onion Architecture, CQRS, Repository Pattern

- Proje çalışmadan önce local veritabanına (PostgreSQL) `postgres` adında bir veritabanı oluşturmak veya connectionstring'i kendinize göre düzenlemeniz gerekir.

- Proje codefirst olup İlk açılışta connection sağlandıktan sonra update-database yapmak yeterli olacaktır.

- Sonrasında KeyCloak,REDIS ve PostgtreSQL için Docker Desktop'da ayağa kalıdırıp kurulumları yapılmalıdır.

- InstallationDocument adlı dosyanın altında DocReadMe.md içeriisnde step step nasıl kurulum yapılması gerektiği açıklanmaktadır.

***Verilen task için tüm API'lerin açıklaması aşağıda mevcuttur*** :

## Yeni kullanıcı oluşturma
```http
  POST /api/User/create
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `phoneNumber` | `string` | Yeni kayıt için numarası |
| `password` | `string` | Kullanıcı parolası |
| `email` | `string` | Kullanıcı email adresi |
#### Açıklama
- Bu API yeni kullanıcı oluşturmak içindir ilk başta DB'de bir kayıt oluşturur sonrasında ise KeyCloak tarafında karşılığını oluşturarak eşleştirilir.


## SMS Gönderme
```http
  POST /api/Auth/send-sms
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `phoneNumber` | `string` | Yeni kayıt için numarası |
| `countryCode` | `string` | Yeni kullanıcı ülke kodu ALPHA3 ====> TUR,GER,JPN vs.. |

#### Açıklama
- Bu API isteğe bağlı olarak senaryoya dahil edilebilir SMS doğrulama için konulmuştur.


## SMS Kodunu Doğrulama

```http
  POST /api/Auth/verify-sms-code
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `phoneNumber` | `string` | Kullanıcı telefon numarası |
| `code` | `string` | Kullanıcıya gelen doğrulama kodu |

#### Açıklama
- /api/Auth/send-sms API'sinden gelen doğrulama kodu burada verify edilir.


## Token Oluşturma
```http
  POST /api/Auth/create-token
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userId` | `uuid` | Kullanıcı ID'si Guid |
| `password` | `string` | Kullanıcı parolası |
| `phoneNumber` | `string` | Kullanıcı telefon numarası |
| `email` | `string` | Kullanıcı email adresi |
#### Açıklama
- KeyCloak üzerinden JWT Token üretmeye yarayan API'dir.


## Keycloak Erişim Token Alma
```http
  POST /api/Auth/keycloak-access-token
```

#### Açıklama
- Herhangi bir paratmere olmadan {} boş body şeklinde yollanır KeyCloak için master-user üzerinden token alıp REDIS'e key-value olarak yazar. Authorize gerekir.


## Oturum Açma
```http
  POST /api/Auth/login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `phoneNumber` | `string?` | Ürün Adı |
| `email` | `string?` | Ürün Stok Miktarı |
| `password` | `string?` | Ürün Fiyatı |

#### Açıklama
- Oturum açma API'sidir kişi phoneNumber veya email'den sadece birini girmesi yeterli olacaktır. İstenirse daha fazla eklenebilir userName,TcKimlik vs..
- Oturum açma işleminden sonra geri kalan tüm API'lere Authorize olmak gerekir yoksa 401 Unauthorized hatası dönecektir.


## Kullanıcının Sepet Öğelerini Listeleme
```http
  GET /api/Basket/user-basket-items
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userId` | `uuid` | Kullanıcı Id değeri Guid |

#### Açıklama
- Kullanıcı bazlı sepet öğelerini listeleme için kullanılan API.

## Kullanıcıya Sepet Öğesi Ekleme
```http
  POST /api/Basket/add-basket-item
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userId` | `uuid` | Kullanıcı Id değeri Guid |
| `productId` | `uuid` | Ürün Id değeri Guid |
| `quantity` | `int` | ürün miktarı |

#### Açıklama
- Kullanıcı bazlı sepet'e ürün eklemek için kullanılan API.


## Sepet ürün miktarı güncelleme
```http
  PUT /api/Basket/update-basket-item-quantity
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `basketItemId` | `uuid` | basket'e eklenmiş ürün Id'si Guid |
| `quantity` | `int` | ürün miktarı |

#### Açıklama
- Kullanıcı bazlı sepet'e ürün eklemek için kullanılan API'dir.

## Sepetten ürün silme
```http
  DELETE /api/Basket/delete-basket-item
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `basketItemId` | `uuid` | basket'e eklenmiş ürün Id'si Guid |

#### Açıklama
- basketItemId paramtersine göre kişinin sepetinden ürün siler.


## Ürünleri Listeleme
```http
  GET /api/Product/list-all
```

#### Açıklama
- Herhangi bir paramtere beklemez tüm ürünleri listeler isteğe bağlı pagination koyulabilir Skip ve Take ile beraber.


## Ürün Ekleme
```http
  POST /api/Product/create
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | Ürün Adı |
| `stock` | `int` | Ürün Stok Miktarı |
| `price` | `float` | Ürün Fiyatı |
| `productGroupId` | `Guid` | Ürünün Hangi Kategoriye ait olduğu |

#### Açıklama
- Ürün eklemek için kategorisi olması gerekir bu yüzden öncelikle kategori ekleyip sonra ürün eklemek önerilir


## Ürün Kategorisi Ekleme
```http
  POST api/ProductGroup
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | Ürünün Eşleşeceği Ürün Kategorisinin Adı |

#### Açıklama
- Ürün kategorisinin adını girmemiz yeterli olacaktır Base'den Guid olarak bir Guid değeri basılacak sonrasında ürün eklerken bu Kategori ile eşleştirebileceğiz.

## Ürün Silme
```http
  DELETE /api/Product/{id}
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `id` | `uuid` | ÜrünId'si Guid |

#### Açıklama
- Ürün silmek için sadece ilgili ürünün Guid değerini girmek yeterlidir.

