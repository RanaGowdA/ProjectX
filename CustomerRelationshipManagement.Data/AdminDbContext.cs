using CustomerRelationshipManagement.Data.Models;
using CustomerRelationshipManagement.Shared;
using CustomerRelationshipManagement.Shared.Models;
using CustomerRelationshipManagement.Shared.Models.AccountConfig;
using CustomerRelationshipManagement.Shared.Models.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        #region Admin Datasets
        public DbSet<ProjectAccount> ProjectAccounts { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Engagement> EngagementModels { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion Admin Datasets

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

            modelBuilder.Entity<Lead>().HasOne(x => x.Account).WithMany(x => x.Leads).HasForeignKey(x => x.LeadId);
            modelBuilder.Entity<Lead>().Property(s => s.IsLCFL).HasDefaultValue(false);
            modelBuilder.Entity<Lead>().Property(s => s.IsLCFO).HasDefaultValue(false);
            modelBuilder.Entity<Lead>().Property(s => s.IsLCFP).HasDefaultValue(false);
        }

    }
}
