using DispoHub.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DispoHub.Shared.Infrastructure.Persistence.Mappings
{
    public class LicenceMappings : IEntityTypeConfiguration<Licence>
    {
        public void Configure(EntityTypeBuilder<Licence> builder)
        {
            builder.ToTable("Licences");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Active)
                   .IsRequired()
                   .HasColumnName("Active")
                   .HasDefaultValue(true);

            builder.Property(x => x.Key)
                   .IsRequired()
                   .HasColumnName("Key")
                   .HasColumnType("VARCHAR(100)")
                   .HasMaxLength(100);

            builder.Property(x => x.CreationDate)
                   .IsRequired()
                   .HasColumnName("CreationDate")
                   .HasColumnType("datetime2");

            builder.Property(x => x.ExpirationDate)
                   .IsRequired()
                   .HasColumnName("ExpirationDate")
                   .HasColumnType("datetime2");

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.HasOne(a => a.Company)
                   .WithOne(b => b.Licence)
                   .HasForeignKey<Licence>(c => c.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}