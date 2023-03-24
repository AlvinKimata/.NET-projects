using Microsoft.AspNetCore.Identity;

namespace User_management.Models
{
    public class ApplicationUser : IdentityUser
    {
        public new int Id { get; set; }
        public override string UserName { get; set; }
    }
}
