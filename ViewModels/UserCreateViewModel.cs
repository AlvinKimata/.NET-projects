using System.ComponentModel.DataAnnotations;

namespace User_management.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]  
        public string? Id { get; set; }
        [Required]
        public string? Email { get; set; }

    }
}
