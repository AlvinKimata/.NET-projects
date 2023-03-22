using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User_management.Models;

namespace User_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult Index()
        {
            var model = _userRepository.GetAllUsers();
            return View(model);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


    }
}