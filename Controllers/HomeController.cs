﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User_management.Models;

namespace User_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult Index()
        {
            return View();
        }


    }
}