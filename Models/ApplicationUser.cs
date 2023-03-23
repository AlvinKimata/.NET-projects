using Microsoft.AspNetCore.Identity;

namespace User_management.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
    }
}
