using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Identity_MVC.Models
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
    }
}
