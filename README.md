# .NET CORE WebAPI

Ben [`Kamil KAPLAN`][medium] medium adresimde **.NET CORE WEB API - NOTLAR** üzerine bir makale yazdım orayada bakmanızı öneririm.

```sh
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        /* api/users */
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        /* api/users/12 */
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        /* api/users */
        public User Post([FromBody] User user)
        {
            user.Id = _users.Count() + 1;
            _users.Add(user);
            return user;
        }

        [HttpPut]
        /* api/users */
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Address = user.Address;
            return user;
        }

        [HttpDelete("{id}")]
        /* api/users/12 */
        public string Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
            return $"{id} nolu {deletedUser.FirstName} silme işlemi başasılı";
        }
    }
```

- `[Route("api/[controller]")]` : URL kısmının yolunu belirler, `https://localhost:5001/api/values` controller 'ın ismi
- `[ApiController]` : niteliği, Web API isteklerine cevap vereceğini gösterir.

---

- `[HttpGet]` : GET api/users 
- `[HttpGet("{id}")]` : GET api/users/5
- `[HttpPost]` : POST api/users
- `[HttpPut("{id}")]` : PUT api/users
- `[HttpDelete("{id}")]` : DELETE api/users/5

**Bu arada hızlı işlemler için memory kullanmak iyi bir çözümdür.**

- .NET Core otomatik olarak nesneyi **JSON** şekline **serialize** eder ve JSON formatında istemciye gönderilir. Burada cevap kodu **200** değerindedir. Eğer URL üzerinden yapılan istek bulunmuyorsa cevap kodu **404** gönderir. Belirlenemeyen hatalar **5xx** cevap kodunu döndürür.

```
/* Static dosya için wwroot klasörü kullanılır.
 * Uygulama içinde olmadığı için sıfırdan kurmak gereklidir.
 * wwwroot klasörünü aktive etmek için Startup.cs dosyasına Configure metodu içine aşağıdaki kod satırları eklenır.
    * app.UseDefaultFiles();
    * app.UseStaticFiles();
 * Static sayfaların kullanımı ile ilgili daha fazla detay da var. Şu adrese(https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-5.0) bakmanızı öneririm
 */
```

- **Bogus kütüphanesi** kullanılarak Fake Data üretimi yapılmaktadır.

- Eğer bir Web API uygulaması geliştiriyorsanız, farklı metotları üretmek bir geliştirici için zordur. **Swagger (OpenAPI)** problemi çözmek için iyi dokümanlara sahip ve yardım sayfaları olan iyi bir çözümdür. Bu uygulama bir .Net Core çözümü değildir. Ancak, [Swashbuckle][swagger].AspNetCore ve NSwag projeleri ASP.NET Core Web API’leri için dokümantasyon üretmek için açık kaynak kodlu olarak Swagger uygulamasının kullanıma olanak sağlar.

**KAMIL KAPLAN - SOFTWARE ENGINEER**

[//]: # (Gizli alan)

 [medium]: <https://medium.com/@kamilkaplnnr>
 [swagger]: <https://swagger.io/>





























