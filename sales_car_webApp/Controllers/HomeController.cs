using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Error() 
        {

            //.net will take care of finding the view
            return View();
            
        }
    }
}
