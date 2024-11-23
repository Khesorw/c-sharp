using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
namespace Lab3.Controllers
{
    public class HomeController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SongForm() { 
        
        
            return View();
        }

        [HttpPost]
        public IActionResult Sing()
        {

            var a = Request.Form["nBottle"];


            ViewBag.number = a;
            return View();
        }



        public IActionResult CreateStudent() => View();

        [HttpPost]
        public IActionResult DisplayStudent(Student student)
        {



           
            


            return View(student);


        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
