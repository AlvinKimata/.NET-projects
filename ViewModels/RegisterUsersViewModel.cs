using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace User_management.ViewModels
{
    public class RegisterUsersViewModel 
    {
        [Required]
        public string Name { get; set; }    
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and confirmation password must match")]
        public string ConfirmPassword { get; set;}
    }
}
