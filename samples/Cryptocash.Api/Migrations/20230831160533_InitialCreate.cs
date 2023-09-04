using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cryptocash.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CurrencyIsoNumeric = table.Column<short>(type: "smallint", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    ThousandsSeparator = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    DecimalSeparator = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    SpaceBetweenAmountAndSymbol = table.Column<bool>(type: "bit", nullable: false),
                    DecimalDigits = table.Column<int>(type: "int", nullable: false),
                    MajorName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MajorSymbol = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MinorName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MinorSymbol = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MinorToMajorValue_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    MinorToMajorValue_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstWorkingDay = table.Column<DateTime>(type: "date", nullable: false),
                    LastWorkingDay = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandLords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankNotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNote = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    IsRare = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankNotes_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    CountryIsoNumeric = table.Column<int>(type: "int", nullable: true),
                    CountryIsoAlpha3 = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    GeoCoords_Latitude = table.Column<decimal>(type: "decimal(8,6)", precision: 8, scale: 6, nullable: true),
                    GeoCoords_Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    FlagEmoji = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    FlagSvg_Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    FlagSvg_PrettyName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    FlagSvg_SizeInBytes = table.Column<int>(type: "int", nullable: true),
                    FlagPng_Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    FlagPng_PrettyName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    FlagPng_SizeInBytes = table.Column<int>(type: "int", nullable: true),
                    CoatOfArmsSvg_Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    CoatOfArmsSvg_PrettyName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    CoatOfArmsSvg_SizeInBytes = table.Column<int>(type: "int", nullable: true),
                    CoatOfArmsPng_Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    CoatOfArmsPng_PrettyName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    CoatOfArmsPng_SizeInBytes = table.Column<int>(type: "int", nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    OpenStreetMapsUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    StartOfWeek = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveRate = table.Column<int>(type: "int", nullable: false),
                    EffectiveAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhoneNumber",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumber_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<float>(type: "real", maxLength: 2, nullable: false),
                    EffectiveAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountryHolidays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryHolidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryHolidays_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountryTimeZones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeZoneCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimeZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTimeZones_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendingMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MacAddress = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    PublicIp = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    GeoLocation_Latitude = table.Column<decimal>(type: "decimal(8,6)", precision: 8, scale: 6, nullable: false),
                    GeoLocation_Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    StreetAddress_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StreetAddress_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StreetAddress_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StreetAddress_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddress_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddress_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddress_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddress_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddress_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StreetAddress_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    InstallationFootPrint = table.Column<decimal>(type: "DECIMAL(21,6)", nullable: true),
                    RentPerSquareMetre_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: true),
                    RentPerSquareMetre_CurrencyCode = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    LandLordId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendingMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendingMachines_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendingMachines_LandLords_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "LandLords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAccountName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentAccountNumber = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentAccountSortCode = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountFrom_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    AmountFrom_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    AmountTo_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    AmountTo_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    RequestedPickUpDate_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedPickUpDate_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickedUpDateTime_Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickedUpDateTime_End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CancelledDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumber_Number = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    VatNumber_CountryCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    VendingMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommissionId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MinimumCashStocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    VendingMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinimumCashStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinimumCashStocks_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MinimumCashStocks_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendingMachineOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    RequestedDeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeliveryDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendingMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendingMachineOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendingMachineOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendingMachineOrders_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentProviders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentProviderName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentProviderType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CustomerPaymentDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentProviders_CustomerPaymentDetails_CustomerPaymentDetailsId",
                        column: x => x.CustomerPaymentDetailsId,
                        principalTable: "CustomerPaymentDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    ProcessedOnDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerTransactions_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerTransactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankNotes_CurrencyId",
                table: "BankNotes",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CommissionId",
                table: "Bookings",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VendingMachineId",
                table: "Bookings",
                column: "VendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_CountryId",
                table: "Commissions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryHolidays_CountryId",
                table: "CountryHolidays",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimeZones_CountryId",
                table: "CountryTimeZones",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentDetails_CustomerId",
                table: "CustomerPaymentDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_BookingId",
                table: "CustomerTransactions",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransactions_CustomerId",
                table: "CustomerTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumber_EmployeeId",
                table: "EmployeePhoneNumber",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CurrencyId",
                table: "ExchangeRates",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MinimumCashStocks_CurrencyId",
                table: "MinimumCashStocks",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MinimumCashStocks_VendingMachineId",
                table: "MinimumCashStocks",
                column: "VendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentProviders_CustomerPaymentDetailsId",
                table: "PaymentProviders",
                column: "CustomerPaymentDetailsId",
                unique: true,
                filter: "[CustomerPaymentDetailsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachineOrders_EmployeeId",
                table: "VendingMachineOrders",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachineOrders_VendingMachineId",
                table: "VendingMachineOrders",
                column: "VendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_CountryId",
                table: "VendingMachines",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_LandLordId",
                table: "VendingMachines",
                column: "LandLordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankNotes");

            migrationBuilder.DropTable(
                name: "CountryHolidays");

            migrationBuilder.DropTable(
                name: "CountryTimeZones");

            migrationBuilder.DropTable(
                name: "CustomerTransactions");

            migrationBuilder.DropTable(
                name: "EmployeePhoneNumber");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "MinimumCashStocks");

            migrationBuilder.DropTable(
                name: "PaymentProviders");

            migrationBuilder.DropTable(
                name: "VendingMachineOrders");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CustomerPaymentDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "VendingMachines");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LandLords");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
