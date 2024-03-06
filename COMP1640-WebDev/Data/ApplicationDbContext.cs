using COMP1640_WebDev.Models;
using COMP1640_WebDev.Ultils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace COMP1640_WebDev.Data;

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
        SeedRoles(builder);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "089967f7-aeef-4edb-8fff-b2945b7f67ee",
                Name = Role.ADMIN,
                ConcurrencyStamp = "1",
                NormalizedName = Role.ADMIN
            },
            new IdentityRole
            {
                Id = "089967f7-aeef-4edb-8fff-b2945b7f67e2",
                Name = Role.MARKETING_MANAGER,
                ConcurrencyStamp = "2",
                NormalizedName = Role.MARKETING_MANAGER
            },
            new IdentityRole
            {
                Id = "089967f7-aeef-4edb-8fff-b2945b7f67e3",
                Name = Role.MARKETING_COORDINATOR,
                ConcurrencyStamp = "3",
                NormalizedName = Role.MARKETING_COORDINATOR
            },
            new IdentityRole
            {
                Id = "089967f7-aeef-4edb-8fff-b2945b7f67e4",
                Name = Role.STUDENT,
                ConcurrencyStamp = "4",
                NormalizedName = Role.STUDENT
            },
            new IdentityRole
            {
                Id = "089967f7-aeef-4edb-8fff-b2945b7f67e5",
                Name = Role.GUEST,
                ConcurrencyStamp = "5",
                NormalizedName = Role.GUEST
            }
        );

        builder.Entity<User>().HasData(
            new User
            {
                Id = "089967f7-aeef-4edb-8fff-b2945b7f67e1",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEKP/gJ6XGMLQpnKKGQH7IsGMKoqwwAyh5MGKWcnLP3OBjP/DRkS4PFY1BfiRbVjfWg==",
                SecurityStamp = "VAXURNACT25EQBDVHYPTL7OHXP6OHZXM",
                ConcurrencyStamp = "d719e974-32f6-4ff1-b45b-5e1f5ca82808",
                TwoFactorEnabled = false,
                LockoutEnabled = true
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = "089967f7-aeef-4edb-8fff-b2945b7f67e1",
                RoleId = "089967f7-aeef-4edb-8fff-b2945b7f67ee"
            }
        );
    }
}
