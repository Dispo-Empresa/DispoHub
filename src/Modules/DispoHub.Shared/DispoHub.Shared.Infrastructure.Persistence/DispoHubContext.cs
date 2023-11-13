using DispoHub.Shared.Domain.Entities;
using DispoHub.Shared.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DispoHub.Shared.Infrastructure.Persistence
{
    public class DispoHubContext : DbContext
    {
        public DispoHubContext(DbContextOptions<DispoHubContext> options) : base(options)
        {
        }

        public DispoHubContext()
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Licence> Licences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMappings());
            modelBuilder.ApplyConfiguration(new LicenceMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}