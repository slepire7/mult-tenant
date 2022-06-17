using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AllDbTenantsContext : DbContext
    {
        public AllDbTenantsContext(DbContextOptions<AllDbTenantsContext> option) : base(option)
        {

        }
        public DbSet<Core.Model.Apps.Crm.Clientes> Clientes { get; set; }
    }
}
