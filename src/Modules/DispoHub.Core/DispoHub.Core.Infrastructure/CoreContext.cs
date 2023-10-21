using DispoHub.Core.Domain.Entities;
using DispoHub.Core.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DispoHub.Core.Infrastructure
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        public CoreContext() { }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}
