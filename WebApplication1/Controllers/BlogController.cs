using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Route("blog")]
    public class BlogController : Controller
    {


        private readonly BlogDataContext _db;

        public BlogController (BlogDataContext db){

            this._db = db;
           
         }

        [Route("index")]
        public IActionResult Index()
        {


            var post = _db.Posts.ToArray();

            var p = post[0];
           
            return View(p);
        }


       [Route("{name:alpha:minlength(3)}/{lname:alpha:minlength(3)}/{title?}")]
       
        public IActionResult post(string name,string lname,string title)
        {
           

            var post = _db.Posts.ToArray()[0];

            
           
         
            
            return View(post);
        }


           [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }


          [HttpPost, Route("create")]
       
        public IActionResult Create (Post post)
        {

           

            _db.Posts.Add(post);
            _db.SaveChanges();



            return RedirectToAction("post", "blog", new
            {

                name = post.Name,lname = post.lname,title = post.title
            });
            
            
        }



        public IActionResult Check(){
            
            return View();
        }


    }
}
