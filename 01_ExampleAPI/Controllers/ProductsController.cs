using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers
{
    /* 
     * Tanımlamış olduğumuz class'ta controller olarak devam edebilmek için 
     * ControllerBase class'ından miras almamız gerekmektedir.  
     */
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [Route("hello")]
        public string Hello() { return "Hello"; }

        [Route("hi")]
        public string Hi() { return "Hi"; }
    }
}