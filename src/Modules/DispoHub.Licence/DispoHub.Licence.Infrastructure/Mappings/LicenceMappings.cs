﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DispoHub.Licence.Infrastructure.Mappings
{
    public class LicenceMappings : IEntityTypeConfiguration<Domain.Entities.Licence>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Licence> builder)
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
        }
    }
}
