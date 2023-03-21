using ASP.NET_Identity_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_Identity_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IdentityRepository _identityRepository;

        public HomeController(IdentityRepository identityRepository)
        { 
            _identityRepository = identityRepository;
        }

       public ViewResult Index()
        {
            var model = _identityRepository.GetEmployees();
            return View(model);
        }
    }
}