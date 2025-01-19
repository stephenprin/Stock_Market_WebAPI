using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock_Market_WebAPI.Models;
using System;
using System.Collections.Generic;

namespace Stock_Market_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AddUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define your DbSets for the application
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base implementation of OnModelCreating
            base.OnModelCreating(modelBuilder);

            // Seed IdentityRoles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            // Add the roles to the model
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
