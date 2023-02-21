using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspnet_core_Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aspnet_core_Identity.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public ResetPassword Model { get; set; }

        public string Password { get; set; }
        public string Email { get; private set; }
        public string ConfirmPassword { get; private set; }

        public ResetPasswordModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        

        public void OnGet()
        {

        }
        public async Task <IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //Validate user credentials.
                var user = await userManager.FindByEmailAsync(Model.Email);
                if (user != null)
                {
                    var new_password = await userManager.ChangePasswordAsync(user, Model.Password, Model.ConfirmPassword);
                }
                ModelState.AddModelError("", "The email does not exist");
            }
            return Page();
        }

    }
}
