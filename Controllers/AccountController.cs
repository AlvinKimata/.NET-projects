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

        public ViewResult Index()
        {
            var model = _userRepository.GetAllUsers();
            return View(model);
        }
    }
}
