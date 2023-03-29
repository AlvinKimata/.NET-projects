using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace User_management.Models
{
    public class AppDbContext : IdentityDbContext
    {
        protected readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration,
                            DbContextOptions<AppDbContext> options) : base(options)
        {
            this.configuration = configuration;
        }

        public new DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("IdentityDBConnect"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();

        }
    }
}
