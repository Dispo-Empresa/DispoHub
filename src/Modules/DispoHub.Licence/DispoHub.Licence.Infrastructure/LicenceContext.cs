using DispoHub.Licence.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DispoHub.Licence.Infrastructure
{
    public class LicenceContext : DbContext
    {
        public LicenceContext(DbContextOptions<LicenceContext> options) : base(options) { }
        public LicenceContext() { }

        public DbSet<Domain.Entities.Licence> Licences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LicenceMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}
