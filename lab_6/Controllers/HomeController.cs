﻿using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
