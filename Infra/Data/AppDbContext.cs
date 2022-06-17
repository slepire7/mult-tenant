using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<Core.Model.User> User { get; set; }
        public DbSet<Core.Model.Tenant> Tenant { get; set; }
    }
}
