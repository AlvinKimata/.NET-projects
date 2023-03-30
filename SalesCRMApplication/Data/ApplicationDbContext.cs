using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesCRMApplication.Models;

namespace SalesCRMApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Define Dbset.
        public DbSet<SalesLeadEntity> SalesLead { get; set; }
    }
}
