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



            var fName = Request.Form["firstName"];
            var lName = Request.Form["lastName"];
            var number = Request.Form["studentId"];
            var email = Request.Form["email_Address"];
            var password = Request.Form["password"];
            var desc = Request.Form["description_of_student"];

            // you will complete this
            student = new Student
            {
                FristName = fName,
                LastName = lName,
                StudentId = int.Parse(number),
                EmailAddress = email,
                Password = password,
                Description_Of_Student = desc
                
                
            };

            ViewBag.fname = student.FristName;
            ViewBag.lname = student.LastName;
            ViewBag.id = student.StudentId;
            ViewBag.email = student.EmailAddress;
            ViewBag.password = student.Password;
            ViewBag.desc = student.Description_Of_Student;


            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
