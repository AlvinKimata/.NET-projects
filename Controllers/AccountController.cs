using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using User_management.Models;

namespace User_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Register()
        {
            return View();
        }
        public ViewResult Index()
        {
            var model = _userRepository.GetAllUsers();
            return View(model);
        }

        public ViewResult Details(int Id)
        {
            var user = _userRepository.GetUser(Id);
            return View(user);
        }
    }
}
