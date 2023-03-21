using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ASP.NET_Identity_MVC.Models
{
    public class ProjectDbContext : IdentityDbContext
    {
        protected readonly IConfiguration configuration;
        public ProjectDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("IdentityDBConnect"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        
        public DbSet<Employees> Employees { get; set; }
    }
}
