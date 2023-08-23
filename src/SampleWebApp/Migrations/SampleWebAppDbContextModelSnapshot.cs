﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebApp.Infrastructure.Persistence;

#nullable disable

namespace SampleWebAppdeprecated.Migrations
{
    [DbContext(typeof(SampleWebAppDbContext))]
    partial class SampleWebAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CountryCurrency", b =>
                {
                    b.Property<long>("CountriesId")
                        .HasColumnType("bigint");

                    b.Property<uint>("CurrenciesId")
                        .HasColumnType("bigint");

                    b.HasKey("CountriesId", "CurrenciesId");

                    b.HasIndex("CurrenciesId");

                    b.ToTable("CountryCurrency");
                });

            modelBuilder.Entity("SampleWebApp.Domain.AllNoxType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("TextId")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("BooleanField")
                        .HasColumnType("bit");

                    b.Property<string>("CountryCode2Field")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("CountryCode3Field")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<ushort?>("CountryNumberField")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedVia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CultureCodeField")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .IsFixedLength(false);

                    b.Property<string>("CurrencyCode3Field")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<short>("CurrencyNumberField")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateField")
                        .HasColumnType("date");

                    b.Property<long>("DateTimeDurationField")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateTimeField")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DateTimeScheduleField")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DeletedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("HtmlField")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternetDomainField")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(false)
                        .HasColumnType("varchar(63)");

                    b.Property<string>("IpAddressField")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("JsonField")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JwtTokenField")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCodeField")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<DateTimeOffset?>("LastUpdatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastUpdatedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("LengthField")
                        .HasColumnType("DECIMAL(21, 6)");

                    b.Property<string>("MacAddressField")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .IsFixedLength();

                    b.Property<string>("MarkdownField")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte>("MonthField")
                        .HasColumnType("tinyint");

                    b.Property<uint?>("NuidField")
                        .HasColumnType("bigint");

                    b.Property<int?>("NumberField")
                        .HasColumnType("int");

                    b.Property<float?>("PercentageField")
                        .HasMaxLength(2)
                        .HasColumnType("real");

                    b.Property<string>("PhoneNumberField")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("TemperatureField")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TextField")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.Property<TimeSpan?>("TimeField")
                        .HasColumnType("time");

                    b.Property<string>("TimeZoneCodeField")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("UriField")
                        .HasMaxLength(2083)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2083)");

                    b.Property<string>("UrlField")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<decimal?>("VolumeField")
                        .HasColumnType("DECIMAL(9, 6)");

                    b.Property<decimal?>("WeightField")
                        .HasColumnType("DECIMAL(9, 6)");

                    b.Property<string>("YamlField")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<ushort?>("YearField")
                        .HasColumnType("int");

                    b.HasKey("Id", "TextId");

                    b.ToTable("AllNoxTypes");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

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

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedVia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("DeletedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DeletedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

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

                    b.Property<DateTimeOffset?>("LastUpdatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastUpdatedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

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

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Currency", b =>
                {
                    b.Property<uint>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedVia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("DeletedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DeletedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("LastUpdatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastUpdatedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("SampleWebApp.Domain.CurrencyCashBalance", b =>
                {
                    b.Property<string>("StoreId")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<uint>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedVia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("DeletedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DeletedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("LastUpdatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastUpdatedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("OperationLimit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StoreId", "CurrencyId");

                    b.HasIndex("CurrencyId")
                        .IsUnique();

                    b.HasIndex("StoreId")
                        .IsUnique();

                    b.ToTable("CurrencyCashBalances");
                });

            modelBuilder.Entity("SampleWebApp.Domain.Store", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedVia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("DeletedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DeletedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("LastUpdatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastUpdatedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(63)");

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

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedVia")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("DeletedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DeletedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTimeOffset?>("LastUpdatedAtUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastUpdatedVia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

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
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("StoreId")
                        .IsUnique()
                        .HasFilter("[StoreId] IS NOT NULL");

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
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("PrettyName")
                                .IsRequired()
                                .HasMaxLength(511)
                                .HasColumnType("nvarchar(511)");

                            b1.Property<decimal>("SizeInBytes")
                                .HasColumnType("decimal(20,0)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasMaxLength(2083)
                                .HasColumnType("nvarchar(2083)");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.HashedText", "HashedTexField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("HashText")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Salt")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.Image", "ImageField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("PrettyName")
                                .IsRequired()
                                .HasMaxLength(511)
                                .HasColumnType("nvarchar(511)");

                            b1.Property<int>("SizeInBytes")
                                .HasColumnType("int");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasMaxLength(2083)
                                .HasColumnType("nvarchar(2083)");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.Password", "PasswordField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("HashedPassword")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Salt")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.StreetAddress", "StreetAddressField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

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

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.TranslatedText", "TranslatedTextField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("CultureCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phrase")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.VatNumber", "VatNumberField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("CountryCode")
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

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.OwnsOne("Nox.Types.Money", "MoneyField", b1 =>
                        {
                            b1.Property<long>("AllNoxTypeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AllNoxTypeTextId")
                                .HasColumnType("nvarchar(255)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(13, 4)");

                            b1.Property<int>("CurrencyCode")
                                .HasColumnType("int");

                            b1.HasKey("AllNoxTypeId", "AllNoxTypeTextId");

                            b1.ToTable("AllNoxTypes");

                            b1.WithOwner()
                                .HasForeignKey("AllNoxTypeId", "AllNoxTypeTextId");
                        });

                    b.Navigation("FileField")
                        .IsRequired();

                    b.Navigation("HashedTexField")
                        .IsRequired();

                    b.Navigation("ImageField")
                        .IsRequired();

                    b.Navigation("MoneyField")
                        .IsRequired();

                    b.Navigation("PasswordField")
                        .IsRequired();

                    b.Navigation("StreetAddressField");

                    b.Navigation("TranslatedTextField")
                        .IsRequired();

                    b.Navigation("VatNumberField")
                        .IsRequired();
                });

            modelBuilder.Entity("SampleWebApp.Domain.Country", b =>
                {
                    b.OwnsOne("Nox.Types.LatLong", "GeoCoord", b1 =>
                        {
                            b1.Property<long>("CountryId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Latitude")
                                .HasPrecision(8, 6)
                                .HasColumnType("decimal(8,6)");

                            b1.Property<decimal>("Longitude")
                                .HasPrecision(9, 6)
                                .HasColumnType("decimal(9,6)");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.OwnsMany("SampleWebApp.Domain.CountryLocalNames", "CountryLocalNames", b1 =>
                        {
                            b1.Property<string>("Id")
                                .HasMaxLength(2)
                                .IsUnicode(false)
                                .HasColumnType("char(2)")
                                .IsFixedLength();

                            b1.Property<long>("CountryId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("CountryId");

                            b1.ToTable("CountryLocalNames");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.Navigation("CountryLocalNames");

                    b.Navigation("GeoCoord");
                });

            modelBuilder.Entity("SampleWebApp.Domain.CurrencyCashBalance", b =>
                {
                    b.HasOne("SampleWebApp.Domain.Currency", "Currency")
                        .WithOne()
                        .HasForeignKey("SampleWebApp.Domain.CurrencyCashBalance", "CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleWebApp.Domain.Store", "Store")
                        .WithOne()
                        .HasForeignKey("SampleWebApp.Domain.CurrencyCashBalance", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Nox.Types.Money", "Amount", b1 =>
                        {
                            b1.Property<string>("CurrencyCashBalanceStoreId")
                                .HasColumnType("char(3)");

                            b1.Property<uint>("CurrencyCashBalanceCurrencyId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(15, 5)");

                            b1.Property<int>("CurrencyCode")
                                .HasColumnType("int");

                            b1.HasKey("CurrencyCashBalanceStoreId", "CurrencyCashBalanceCurrencyId");

                            b1.ToTable("CurrencyCashBalances");

                            b1.WithOwner()
                                .HasForeignKey("CurrencyCashBalanceStoreId", "CurrencyCashBalanceCurrencyId");
                        });

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Store");
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
                        .HasForeignKey("SampleWebApp.Domain.StoreSecurityPasswords", "StoreId");

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
