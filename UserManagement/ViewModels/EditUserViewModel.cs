using System.ComponentModel.DataAnnotations;

namespace User_management.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
