using COMP1640_WebDev.Models;
using COMP1640_WebDev.Ultils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace COMP1640_WebDev.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<AcademicYear>? AcademicYears { get; set; }
        public DbSet<Contribution>? Contributions { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Notification>? Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
             new IdentityRole()
             {
                 Name = Role.ADMIN,
                 ConcurrencyStamp = "1",
                 NormalizedName = Role.ADMIN
             },
            new IdentityRole()
            {
                Name = Role.MARKETING_MANAGER,
                ConcurrencyStamp = "2",
                NormalizedName = Role.MARKETING_MANAGER
            },
            new IdentityRole()
            {
                Name = Role.MARKETING_COORDINATOR,
                ConcurrencyStamp = "3",
                NormalizedName = Role.MARKETING_COORDINATOR
            },
            new IdentityRole()
            {
                Name = Role.STUDENT,
                ConcurrencyStamp = "4",
                NormalizedName = Role.STUDENT
            },
            new IdentityRole()
            {
                Name = Role.GUEST,
                ConcurrencyStamp = "5",
                NormalizedName = Role.GUEST
            }
            );
        }
    }
}
