
using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared;
using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;

namespace CustomerRelationshipManagement.Data
{
    public class AdminDbContext : IdentityDbContext<AppUser, AppRole, int,
      IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
      IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TemplateConfiguration> TemplateConfigurations { get; set; }
        public DbSet<EngagementModel> EngagementModels { get; set; }

        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AdminDb.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>()
                .HasIndex("Email", "UserName");
              
            modelBuilder.Entity<TemplateConfiguration>().HasOne(x => x.Account)
                .WithMany(x => x.TemplateConfigurations).HasForeignKey(x => x.AccountId);

            modelBuilder.Entity<EngagementModel>().HasOne(x => x.Account)
                .WithMany(x => x.EngagementModels).HasForeignKey(x => x.AccountId);

            modelBuilder.Entity<Lead>().HasOne(x => x.Account).WithMany(x => x.Leads).HasForeignKey(x => x.LeadId);
            modelBuilder.Entity<Lead>().Property(s => s.IsLCFL).HasDefaultValue(false);
            modelBuilder.Entity<Lead>().Property(s => s.IsLCFO).HasDefaultValue(false);
            modelBuilder.Entity<Lead>().Property(s => s.IsLCFP).HasDefaultValue(false);
        }

    }
}
