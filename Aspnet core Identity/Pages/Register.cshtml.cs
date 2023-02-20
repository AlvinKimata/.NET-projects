using Aspnet_core_Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aspnet_core_Identity.Pages
{
    public class RegisterModel : PageModel
    {
        public Register Model { get; set; }
        public void OnGet()
        {
        }
    }
}
