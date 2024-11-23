using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("Home")]
       // [Route("Home/Index")]
        [Route("~/Home/Index")]
        public IActionResult Index()
        {
            return View();

           // return new ContentResult { Content = "Hello from content result" };
        }
       
        public IActionResult check()
        {

            return View();
        }
    }
}
