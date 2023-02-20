using System.ComponentModel.DataAnnotations;

namespace Aspnet_core_Identity.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
