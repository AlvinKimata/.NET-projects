﻿using Microsoft.EntityFrameworkCore;
using SalesCRMApplication.Models;

namespace SalesCRMApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Define Dbset.
        public DbSet<SalesLeadEntity> SalesLead { get; set; }
    }
}