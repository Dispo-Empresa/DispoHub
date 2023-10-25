using DispoHub.Core.Domain.Entities;
using DispoHub.Core.Infrastructure.Mappings;
using DispoHub.Licence.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DispoHub.Core.Infrastructure
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        public CoreContext()
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Core.Domain.Entities.Licence> Licences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMappings());
            modelBuilder.ApplyConfiguration(new LicenceMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}