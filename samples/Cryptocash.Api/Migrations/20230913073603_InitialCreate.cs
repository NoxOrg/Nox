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
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "LandLords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Address_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "PaymentProviders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentProviderName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentProviderType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "BankNote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashNote = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Value_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Value_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankNote_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    GeoCoords_Latitude = table.Column<double>(type: "float", nullable: true),
                    GeoCoords_Longitude = table.Column<double>(type: "float", nullable: true),
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
                    CountryUsedByCurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Countries_Currencies_CountryUsedByCurrencyId",
                        column: x => x.CountryUsedByCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveRate = table.Column<int>(type: "int", nullable: false),
                    EffectiveAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRate_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinimumCashStocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    MinimumCashStockRelatedCurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_MinimumCashStocks_Currencies_MinimumCashStockRelatedCurrencyId",
                        column: x => x.MinimumCashStockRelatedCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<float>(type: "real", maxLength: 2, nullable: false),
                    EffectiveAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CommissionFeesForCountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Commissions_Countries_CommissionFeesForCountryId",
                        column: x => x.CommissionFeesForCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountryTimeZone",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeZoneCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CountryId = table.Column<string>(type: "char(2)", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimeZone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTimeZone_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Address_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomerBaseCountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Customers_Countries_CustomerBaseCountryId",
                        column: x => x.CustomerBaseCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CountryId = table.Column<string>(type: "char(2)", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holiday_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendingMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MacAddress = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    PublicIp = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    GeoLocation_Latitude = table.Column<double>(type: "float", nullable: false),
                    GeoLocation_Longitude = table.Column<double>(type: "float", nullable: false),
                    StreetAddress_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    StreetAddress_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StreetAddress_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StreetAddress_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StreetAddress_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StreetAddress_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StreetAddress_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StreetAddress_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    StreetAddress_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StreetAddress_CountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    InstallationFootPrint = table.Column<decimal>(type: "DECIMAL(21,6)", nullable: true),
                    RentPerSquareMetre_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: true),
                    RentPerSquareMetre_CurrencyCode = table.Column<int>(type: "int", nullable: true),
                    VendingMachineInstallationCountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    VendingMachineContractedAreaLandLordId = table.Column<long>(type: "bigint", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_VendingMachines_Countries_VendingMachineInstallationCountryId",
                        column: x => x.VendingMachineInstallationCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendingMachines_LandLords_VendingMachineContractedAreaLandLordId",
                        column: x => x.VendingMachineContractedAreaLandLordId,
                        principalTable: "LandLords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAccountName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentAccountNumber = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentAccountSortCode = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    PaymentDetailsUsedByCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentDetailsRelatedPaymentProviderId = table.Column<long>(type: "bigint", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Customers_PaymentDetailsUsedByCustomerId",
                        column: x => x.PaymentDetailsUsedByCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentDetails_PaymentProviders_PaymentDetailsRelatedPaymentProviderId",
                        column: x => x.PaymentDetailsRelatedPaymentProviderId,
                        principalTable: "PaymentProviders",
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
                    BookingForCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    BookingRelatedVendingMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookingFeesForCommissionId = table.Column<long>(type: "bigint", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Bookings_Commissions_BookingFeesForCommissionId",
                        column: x => x.BookingFeesForCommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_BookingForCustomerId",
                        column: x => x.BookingForCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_VendingMachines_BookingRelatedVendingMachineId",
                        column: x => x.BookingRelatedVendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CashStockOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    RequestedDeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeliveryDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashStockOrderForVendingMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CashStockOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashStockOrders_VendingMachines_CashStockOrderForVendingMachineId",
                        column: x => x.CashStockOrderForVendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MinimumCashStockVendingMachine",
                columns: table => new
                {
                    MinimumCashStocksRequiredByVendingMachinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendingMachineRequiredMinimumCashStocksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinimumCashStockVendingMachine", x => new { x.MinimumCashStocksRequiredByVendingMachinesId, x.VendingMachineRequiredMinimumCashStocksId });
                    table.ForeignKey(
                        name: "FK_MinimumCashStockVendingMachine_MinimumCashStocks_VendingMachineRequiredMinimumCashStocksId",
                        column: x => x.VendingMachineRequiredMinimumCashStocksId,
                        principalTable: "MinimumCashStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MinimumCashStockVendingMachine_VendingMachines_MinimumCashStocksRequiredByVendingMachinesId",
                        column: x => x.MinimumCashStocksRequiredByVendingMachinesId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    ProcessedOnDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    TransactionForCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    TransactionForBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Bookings_TransactionForBookingId",
                        column: x => x.TransactionForBookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_TransactionForCustomerId",
                        column: x => x.TransactionForCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
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
                    Address_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Address_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FirstWorkingDay = table.Column<DateTime>(type: "date", nullable: false),
                    LastWorkingDay = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeReviewingCashStockOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Employees_CashStockOrders_EmployeeReviewingCashStockOrderId",
                        column: x => x.EmployeeReviewingCashStockOrderId,
                        principalTable: "CashStockOrders",
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

            migrationBuilder.CreateIndex(
                name: "IX_BankNote_CurrencyId",
                table: "BankNote",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingFeesForCommissionId",
                table: "Bookings",
                column: "BookingFeesForCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingForCustomerId",
                table: "Bookings",
                column: "BookingForCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingRelatedVendingMachineId",
                table: "Bookings",
                column: "BookingRelatedVendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashStockOrders_CashStockOrderForVendingMachineId",
                table: "CashStockOrders",
                column: "CashStockOrderForVendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_CommissionFeesForCountryId",
                table: "Commissions",
                column: "CommissionFeesForCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryUsedByCurrencyId",
                table: "Countries",
                column: "CountryUsedByCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimeZone_CountryId",
                table: "CountryTimeZone",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerBaseCountryId",
                table: "Customers",
                column: "CustomerBaseCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumber_EmployeeId",
                table: "EmployeePhoneNumber",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeReviewingCashStockOrderId",
                table: "Employees",
                column: "EmployeeReviewingCashStockOrderId",
                unique: true,
                filter: "[EmployeeReviewingCashStockOrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRate_CurrencyId",
                table: "ExchangeRate",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_CountryId",
                table: "Holiday",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinimumCashStocks_MinimumCashStockRelatedCurrencyId",
                table: "MinimumCashStocks",
                column: "MinimumCashStockRelatedCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MinimumCashStockVendingMachine_VendingMachineRequiredMinimumCashStocksId",
                table: "MinimumCashStockVendingMachine",
                column: "VendingMachineRequiredMinimumCashStocksId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_PaymentDetailsRelatedPaymentProviderId",
                table: "PaymentDetails",
                column: "PaymentDetailsRelatedPaymentProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_PaymentDetailsUsedByCustomerId",
                table: "PaymentDetails",
                column: "PaymentDetailsUsedByCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionForBookingId",
                table: "Transactions",
                column: "TransactionForBookingId",
                unique: true,
                filter: "[TransactionForBookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionForCustomerId",
                table: "Transactions",
                column: "TransactionForCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_VendingMachineContractedAreaLandLordId",
                table: "VendingMachines",
                column: "VendingMachineContractedAreaLandLordId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_VendingMachineInstallationCountryId",
                table: "VendingMachines",
                column: "VendingMachineInstallationCountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankNote");

            migrationBuilder.DropTable(
                name: "CountryTimeZone");

            migrationBuilder.DropTable(
                name: "EmployeePhoneNumber");

            migrationBuilder.DropTable(
                name: "ExchangeRate");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "MinimumCashStockVendingMachine");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "MinimumCashStocks");

            migrationBuilder.DropTable(
                name: "PaymentProviders");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CashStockOrders");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "VendingMachines");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "LandLords");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
