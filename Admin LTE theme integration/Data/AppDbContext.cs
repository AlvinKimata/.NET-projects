using Admin_LTE_theme_integration.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin_LTE_theme_integration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) 
        { 

        }

        public DbSet<Student> Students { get; set; }
    }
}
