using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User_management.Models;
using User_management.ViewModels;

namespace User_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger,
                              UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View();
        }


    }
}