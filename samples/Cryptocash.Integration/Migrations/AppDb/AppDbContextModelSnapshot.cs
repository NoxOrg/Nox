﻿// <auto-generated />
using System;
using CryptocashIntegration.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cryptocash.Integration.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptocashIntegration.Domain.CountryQueryToCustomTable", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("AsAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("EditDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Etag")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CountriesQueryToCustomTable", (string)null);
                });

            modelBuilder.Entity("CryptocashIntegration.Domain.CountryQueryToTable", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("AsAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Etag")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CountriesQueryToTable", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
