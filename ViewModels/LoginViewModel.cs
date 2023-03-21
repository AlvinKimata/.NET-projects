using System.ComponentModel.DataAnnotations;
using User_management.Models;

namespace User_management.ViewModels
{
    public class LoginViewModel 
{
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set;}

        }
}
