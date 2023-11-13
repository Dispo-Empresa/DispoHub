using DispoHub.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DispoHub.Shared.Infrastructure.Persistence.Mappings
{
    public class CompanyMappings : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Active)
                   .IsRequired()
                   .HasColumnName("Active")
                   .HasDefaultValue(true);

            builder.Property(x => x.CorporateName)
                   .IsRequired()
                   .HasColumnName("CorporateName")
                   .HasColumnType("VARCHAR(220)")
                   .HasMaxLength(220);

            builder.Property(x => x.ResponsibleName)
                   .IsRequired()
                   .HasColumnName("ResponsibleName")
                   .HasColumnType("VARCHAR(220)")
                   .HasMaxLength(220);

            builder.Property(x => x.ResponsiblePhone)
                   .IsRequired()
                   .HasColumnName("ResponsiblePhone")
                   .HasColumnType("VARCHAR(30)")
                   .HasMaxLength(30);

            builder.Property(x => x.CNPJ)
                   .IsRequired()
                   .HasColumnName("Cnpj")
                   .HasColumnType("VARCHAR(18)")
                   .HasMaxLength(18);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasColumnName("Email")
                   .HasColumnType("VARCHAR(220)")
                   .HasMaxLength(220);
        }
    }
}