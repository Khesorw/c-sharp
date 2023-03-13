using Microsoft.AspNetCore.Mvc;

namespace Lab4.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
