using Microsoft.EntityFrameworkCore;

namespace YourProjectName.Data
{
    public class SipStationContext : DbContext
    {
        public SipStationContext(DbContextOptions<SipStationContext> options) : base(options)
        {
        }

        // public DbSet<Admin> Admins { get; set; }
        // public DbSet<Restaurant> Restaurants { get; set; }

    }
}
