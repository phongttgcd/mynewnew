using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace COMP1640_WebDev.Models
{
    public class UniversityDbContext
    {

            public DbSet<Users> Users { get; set; }
            public DbSet<Faculty> Faculties { get; set; }
            public DbSet<Contributions> Contributions { get; set; }
            public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
            public DbSet<ClosureDates> ClosureDates { get; set; }
            public DbSet<ContributorNotification> ContributorNotifications { get; set; }
        

    }
}
