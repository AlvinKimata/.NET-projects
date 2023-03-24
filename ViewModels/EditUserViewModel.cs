using System.ComponentModel.DataAnnotations;

namespace User_management.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
