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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CurrencyIsoNumeric = table.Column<short>(type: "smallint", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    ThousandsSeparator = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    DecimalSeparator = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    SpaceBetweenAmountAndSymbol = table.Column<bool>(type: "bit", nullable: false),
                    SymbolOnLeft = table.Column<bool>(type: "bit", nullable: false),
                    DecimalDigits = table.Column<int>(type: "int", nullable: false),
                    MajorName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MajorSymbol = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MinorName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MinorSymbol = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    MinorToMajorValue_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    MinorToMajorValue_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
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
                    FirstWorkingDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastWorkingDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InboxState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Received = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveCount = table.Column<int>(type: "int", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Consumed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxState", x => x.Id);
                    table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
                });

            migrationBuilder.CreateTable(
                name: "LandLords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
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
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessage",
                columns: table => new
                {
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnqueueTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Headers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InboxMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InboxConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MessageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DestinationAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ResponseAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FaultAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessage", x => x.SequenceNumber);
                });

            migrationBuilder.CreateTable(
                name: "OutboxState",
                columns: table => new
                {
                    OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxState", x => x.OutboxId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProviders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PaymentProviderName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentProviderType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankNotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<string>(type: "char(3)", nullable: true),
                    CashNote = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Value_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Value_CurrencyCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankNotes_Currencies_CurrencyId",
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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
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
                    Population = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    CurrencyId = table.Column<string>(type: "char(3)", nullable: false),
                    EffectiveRate = table.Column<int>(type: "int", nullable: false),
                    EffectiveAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_CurrencyId",
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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinimumCashStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinimumCashStocks_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    PhoneNumberType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumbers_Employees_EmployeeId",
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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Rate = table.Column<float>(type: "real", maxLength: 2, nullable: false),
                    EffectiveAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "CountryTimeZones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<string>(type: "char(2)", nullable: false),
                    TimeZoneCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimeZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTimeZones_Countries_CountryId",
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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
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
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<string>(type: "char(2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendingMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
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
                    CountryId = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    LandLordId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PaymentAccountName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentAccountNumber = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PaymentAccountSortCode = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentProviderId = table.Column<long>(type: "bigint", nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentDetails_PaymentProviders_PaymentProviderId",
                        column: x => x.PaymentProviderId,
                        principalTable: "PaymentProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AmountFrom_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    AmountFrom_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    AmountTo_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    AmountTo_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    RequestedPickUpDate_Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RequestedPickUpDate_End = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PickedUpDateTime_Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PickedUpDateTime_End = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpiryDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CancelledDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumber_Number = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    VatNumber_CountryCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    VendingMachineId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    CommissionId = table.Column<long>(type: "bigint", nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "CashStockOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    RequestedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendingMachineId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashStockOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashStockOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashStockOrders_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendingMachineRequiredMinimumCashStocks",
                columns: table => new
                {
                    MinimumCashStocksId = table.Column<long>(type: "bigint", nullable: false),
                    VendingMachinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendingMachineRequiredMinimumCashStocks", x => new { x.MinimumCashStocksId, x.VendingMachinesId });
                    table.ForeignKey(
                        name: "FK_VendingMachineRequiredMinimumCashStocks_MinimumCashStocks_MinimumCashStocksId",
                        column: x => x.MinimumCashStocksId,
                        principalTable: "MinimumCashStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendingMachineRequiredMinimumCashStocks_VendingMachines_VendingMachinesId",
                        column: x => x.VendingMachinesId,
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
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdatedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedVia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    ProcessedOnDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
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
                name: "IX_CashStockOrders_EmployeeId",
                table: "CashStockOrders",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashStockOrders_VendingMachineId",
                table: "CashStockOrders",
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
                name: "IX_CountryTimeZones_CountryId",
                table: "CountryTimeZones",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumbers_EmployeeId",
                table: "EmployeePhoneNumbers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CurrencyId",
                table: "ExchangeRates",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_CountryId",
                table: "Holidays",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_InboxState_Delivered",
                table: "InboxState",
                column: "Delivered");

            migrationBuilder.CreateIndex(
                name: "IX_MinimumCashStocks_CurrencyId",
                table: "MinimumCashStocks",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_EnqueueTime",
                table: "OutboxMessage",
                column: "EnqueueTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_ExpirationTime",
                table: "OutboxMessage",
                column: "ExpirationTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
                table: "OutboxMessage",
                columns: new[] { "InboxMessageId", "InboxConsumerId", "SequenceNumber" },
                unique: true,
                filter: "[InboxMessageId] IS NOT NULL AND [InboxConsumerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_OutboxId_SequenceNumber",
                table: "OutboxMessage",
                columns: new[] { "OutboxId", "SequenceNumber" },
                unique: true,
                filter: "[OutboxId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxState_Created",
                table: "OutboxState",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_CustomerId",
                table: "PaymentDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_PaymentProviderId",
                table: "PaymentDetails",
                column: "PaymentProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookingId",
                table: "Transactions",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachineRequiredMinimumCashStocks_VendingMachinesId",
                table: "VendingMachineRequiredMinimumCashStocks",
                column: "VendingMachinesId");

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
                name: "CashStockOrders");

            migrationBuilder.DropTable(
                name: "CountryTimeZones");

            migrationBuilder.DropTable(
                name: "EmployeePhoneNumbers");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "InboxState");

            migrationBuilder.DropTable(
                name: "OutboxMessage");

            migrationBuilder.DropTable(
                name: "OutboxState");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "VendingMachineRequiredMinimumCashStocks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PaymentProviders");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MinimumCashStocks");

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
