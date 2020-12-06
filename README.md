# .NET CORE WebAPI

Ben [`Kamil KAPLAN`][medium] medium adresimde **.NET CORE WEB API - NOTLAR** üzerine bir makale yazdım orayada bakmanızı öneririm.

```sh
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
 
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
 
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
 
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
 
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
```

- `[Route("api/[controller]")]` : URL kısmının yolunu belirler, `https://localhost:5001/api/values` controller 'ın ismi
- `[ApiController]` : niteliği, Web API isteklerine cevap vereceğini gösterir.

---

- `[HttpGet]` : GET api/values 
- `[HttpGet("{id}")]` : GET api/values/5
- `[HttpPost]` : POST api/values
- `[HttpPut("{id}")]` : PUT api/values/5
- `[HttpDelete("{id}")]` : DELETE api/values/5

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

- Eğer bir Web API uygulaması geliştiriyorsanız, farklı metotları üretmek bir geliştirici için zordur. **Swagger (OpenAPI)** problemi çözmek için iyi dokümanlara sahip ve yardım sayfaları olan iyi bir çözümdür. Bu uygulama bir .Net Core çözümü değildir. Ancak, [Swashbuckle][swagger].AspNetCore ve NSwag projeleri ASP.NET Core Web API’leri için dokümantasyon üretmek için açık kaynak kodlu olarak Swagger uygulamasının kullanıma olanak sağlar.

**KAMIL KAPLAN - SOFTWARE ENGINEER**

[//]: # (Gizli alan)

 [medium]: <https://medium.com/@kamilkaplnnr>
 [swagger]: <https://swagger.io/>





























