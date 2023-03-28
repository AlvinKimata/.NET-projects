using System.ComponentModel.DataAnnotations;
using User_management.Models;


namespace User_management.ViewModels
{
    public class HomeDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
