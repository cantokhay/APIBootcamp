﻿using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
