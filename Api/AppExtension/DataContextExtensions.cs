using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Api.AppExtension
{
    public static class DataContextExtensions
    {
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Infra.Data.AppDbContext>(option => option.UseNpgsql(Configuration.GetConnectionString("default"),
            builder =>
            {
                builder.EnableRetryOnFailure(2);
                builder.MigrationsAssembly("Infra");
            }),
            ServiceLifetime.Scoped);
        }
        public static void AddTenantAppDbContext(this IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var _httpContextAccessor = provider.GetService<IHttpContextAccessor>();
                string tenantKeyName = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(o => o.Type == "Tenant")?.Value;
                var _context = provider.GetService<Infra.Data.AppDbContext>();
                var tenant = _context.Tenant.FirstOrDefault(tenant => tenant.Nome == tenantKeyName);
                if (tenant is not null)
                {
                    var opts = new DbContextOptionsBuilder<Infra.Data.AllDbTenantsContext>();
                    opts.UseNpgsql(tenant.DbConnection, s =>
                    {
                        s.EnableRetryOnFailure(2);
                        s.MigrationsAssembly("Infra");
                    });
                    opts.EnableSensitiveDataLogging();
                    return new Infra.Data.AllDbTenantsContext(opts.Options);
                }
                return default;
            });
        }
    }
}
