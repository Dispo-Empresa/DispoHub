﻿// <auto-generated />
using System;
using DispoHub.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DispoHub.Shared.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DispoHubContext))]
    [Migration("20231104231539_CreateDispoHubDatabase")]
    partial class CreateDispoHubDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DispoHub.Shared.Domain.Entities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("VARCHAR(18)")
                        .HasColumnName("Cnpj");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("VARCHAR(220)")
                        .HasColumnName("CorporateName");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("VARCHAR(220)")
                        .HasColumnName("Email");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("VARCHAR(220)")
                        .HasColumnName("ResponsibleName");

                    b.Property<string>("ResponsiblePhone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("ResponsiblePhone");

                    b.HasKey("Id");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("DispoHub.Shared.Domain.Entities.Licence", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

                    b.Property<long>("CompanyId")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpirationDate");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Key");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("Licences", (string)null);
                });

            modelBuilder.Entity("DispoHub.Shared.Domain.Entities.Licence", b =>
                {
                    b.HasOne("DispoHub.Shared.Domain.Entities.Company", "Company")
                        .WithOne("Licence")
                        .HasForeignKey("DispoHub.Shared.Domain.Entities.Licence", "CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DispoHub.Shared.Domain.Entities.Company", b =>
                {
                    b.Navigation("Licence")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
