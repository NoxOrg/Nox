﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebApp.Infrastructure.Persistence;

#nullable disable

namespace SampleWebApp.Migrations
{
    [DbContext(typeof(SampleWebAppDbContext))]
    partial class SampleWebAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CountryCurrency", b =>
                {
                    b.Property<string>("CountriesId")
                        .HasColumnType("char(2)");

                    b.Property<string>("CurrenciesId")
                        .HasColumnType("char(3)");

                    b.HasKey("CountriesId", "CurrenciesId");

                    b.HasIndex("CurrenciesId");

                    b.ToTable("CountryCurrency");
                });

            modelBuilder.Entity("SampleWebApp.Domain.AllNoxType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<string>("CountryCode2Field")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("CountryCode3Field")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextField")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AllNoxTypes");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("AlphaCode2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("AlphaCode3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<decimal>("AreaInSquareKilometres")
                        .HasColumnType("DECIMAL(14, 6)");

                    b.Property<string>("Capital")
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Demonym")
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("DialingCodes")
                        .HasMaxLength(31)
                        .IsUnicode(false)
                        .HasColumnType("varchar(31)");

                    b.Property<string>("FormalName")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("GeoRegion")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("GeoSubRegion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("GeoWorldRegion")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<short>("NumericCode")
                        .HasColumnType("smallint");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.Property<string>("TopLevelDomains")
                        .HasMaxLength(31)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(31)");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SampleWebApp.Domain.CountryLocalNames", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CountryLocalNames");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Store", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("SampleWebApp.Domain.StoreSecurityPasswords", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("SecurityCamerasPassword")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StoreId")
                        .IsUnique();

                    b.ToTable("StoreSecurityPasswords");
                });

            modelBuilder.Entity("CountryCurrency", b =>
                {
                    b.HasOne("SampleWebApp.Domain.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleWebApp.Domain.Currency", null)
                        .WithMany()
                        .HasForeignKey("CurrenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SampleWebApp.Domain.AllNoxType", b =>
                {
                    b.OwnsOne("Nox.Types.File", "FileField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<string>("PrettyName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<decimal>("SizeInBytes")
                                .HasColumnType("decimal(20,0)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.HashedText", "HashedTexField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<string>("HashText")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Salt")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.LatLong", "LatLongField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<decimal>("Latitude")
                                .HasPrecision(8, 6)
                                .HasColumnType("decimal(8,6)");

                            b1.Property<decimal>("Longitude")
                                .HasPrecision(9, 6)
                                .HasColumnType("decimal(9,6)");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.Password", "PasswordField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<string>("HashedPassword")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Salt")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.StreetAddress", "StreetAddressField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<string>("AddressLine1")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AddressLine2")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AdministrativeArea1")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AdministrativeArea2")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CountryId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Locality")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Route")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("StreetNumber")
                                .HasColumnType("int");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.TranslatedText", "TranslatedTextField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<string>("CultureCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phrase")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.VatNumber", "VatNumberField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<string>("CountryCode2")
                                .IsRequired()
                                .HasMaxLength(2)
                                .IsUnicode(false)
                                .HasColumnType("char(2)")
                                .IsFixedLength();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(64)
                                .IsUnicode(false)
                                .HasColumnType("varchar(64)");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.OwnsOne("Nox.Types.Money", "MoneyField", b1 =>
                        {
                            b1.Property<string>("AllNoxTypeId")
                                .HasColumnType("char(3)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(13, 4)");

                            b1.Property<int>("CurrencyCode")
                                .HasColumnType("int");

                            b1.HasKey("AllNoxTypeId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId");
                        });

                    b.Navigation("FileField");

                    b.Navigation("HashedTexField");

                    b.Navigation("LatLongField");

                    b.Navigation("MoneyField");

                    b.Navigation("PasswordField");

                    b.Navigation("StreetAddressField");

                    b.Navigation("TranslatedTextField");

                    b.Navigation("VatNumberField");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Store", b =>
                {
                    b.OwnsOne("Nox.Types.Money", "PhysicalMoney", b1 =>
                        {
                            b1.Property<string>("StoreId")
                                .HasColumnType("char(3)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(15, 5)");

                            b1.Property<int>("CurrencyCode")
                                .HasColumnType("int");

                            b1.HasKey("StoreId");

                            b1.ToTable("Stores");

                            b1.WithOwner()
                                .HasForeignKey("StoreId");
                        });

                    b.Navigation("PhysicalMoney")
                        .IsRequired();
                });

            modelBuilder.Entity("SampleWebApp.Domain.StoreSecurityPasswords", b =>
                {
                    b.HasOne("SampleWebApp.Domain.Store", "Store")
                        .WithOne("StoreSecurityPasswords")
                        .HasForeignKey("SampleWebApp.Domain.StoreSecurityPasswords", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Store", b =>
                {
                    b.Navigation("StoreSecurityPasswords")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
