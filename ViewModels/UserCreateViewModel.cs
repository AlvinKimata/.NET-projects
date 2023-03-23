using System.ComponentModel.DataAnnotations;

namespace User_management.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]  
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
