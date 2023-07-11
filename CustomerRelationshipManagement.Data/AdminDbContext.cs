
using CustomerRelationshipManagement.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CustomerRelationshipManagement.Data
{
    public class AdminDbContext : IdentityDbContext<AppUser, AppRole, int>
    {

        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AdminDb.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<AppUser>()
                .HasIndex("AXCIANId", "UserName"); 
            base.OnModelCreating(builder);
        }

    }
}
