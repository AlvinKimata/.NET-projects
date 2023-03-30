using System.ComponentModel.DataAnnotations;

namespace User_management.ViewModels
{
    public class UserCreateViewModel
    {
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }

    }
}
