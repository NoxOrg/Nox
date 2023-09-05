using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAppdeprecated.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllNoxTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AreaField = table.Column<decimal>(type: "DECIMAL(11,6)", nullable: false),
                    BooleanField = table.Column<bool>(type: "bit", nullable: false),
                    CountryCode2Field = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    CountryCode3Field = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CountryNumberField = table.Column<int>(type: "int", nullable: false),
                    CultureCodeField = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CurrencyCode3Field = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyNumberField = table.Column<short>(type: "smallint", nullable: false),
                    DateField = table.Column<DateTime>(type: "date", nullable: false),
                    DateTimeField = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTimeDurationField = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeScheduleField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeekField = table.Column<int>(type: "int", nullable: false),
                    DistanceField = table.Column<decimal>(type: "DECIMAL(15,6)", nullable: false),
                    EmailField = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FormulaField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuidField = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    HtmlField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternetDomainField = table.Column<string>(type: "varchar(63)", unicode: false, maxLength: 63, nullable: false),
                    IpAddressField = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    JsonField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtTokenField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageCodeField = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    LengthField = table.Column<decimal>(type: "DECIMAL(21,6)", nullable: false),
                    MacAddressField = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false),
                    MarkdownField = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MonthField = table.Column<byte>(type: "tinyint", nullable: false),
                    NuidField = table.Column<long>(type: "bigint", nullable: false),
                    NumberField = table.Column<int>(type: "int", nullable: false),
                    PercentageField = table.Column<float>(type: "real", maxLength: 2, nullable: false),
                    PhoneNumberField = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TemperatureField = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TextField = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    TimeField = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeZoneCodeField = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    UriField = table.Column<string>(type: "varchar(2083)", unicode: false, maxLength: 2083, nullable: false),
                    UrlField = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    UserField = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VolumeField = table.Column<decimal>(type: "DECIMAL(9,6)", nullable: false),
                    WeightField = table.Column<decimal>(type: "DECIMAL(9,6)", nullable: false),
                    YamlField = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    YearField = table.Column<int>(type: "int", nullable: false),
                    EncryptedTextField = table.Column<byte[]>(type: "varbinary(max)", unicode: false, nullable: false),
                    FileField_Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    FileField_PrettyName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: false),
                    FileField_SizeInBytes = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HashedTexField_HashText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedTexField_Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageField_Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    ImageField_PrettyName = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: false),
                    ImageField_SizeInBytes = table.Column<int>(type: "int", nullable: false),
                    LatLongField_Latitude = table.Column<double>(type: "float", nullable: false),
                    LatLongField_Longitude = table.Column<double>(type: "float", nullable: false),
                    MoneyField_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
                    MoneyField_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    PasswordField_HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordField_Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddressField_StreetNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StreetAddressField_AddressLine1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StreetAddressField_AddressLine2 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StreetAddressField_Route = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddressField_Locality = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddressField_Neighborhood = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddressField_AdministrativeArea1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddressField_AdministrativeArea2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StreetAddressField_PostalCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StreetAddressField_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatedTextField_Phrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatedTextField_CultureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VatNumberField_Number = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    VatNumberField_CountryCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
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
                    table.PrimaryKey("PK_AllNoxTypes", x => new { x.Id, x.TextId });
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    FormalName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    AlphaCode3 = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    AlphaCode2 = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    NumericCode = table.Column<short>(type: "smallint", nullable: false),
                    DialingCodes = table.Column<string>(type: "varchar(31)", unicode: false, maxLength: 31, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Demonym = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    AreaInSquareKilometres = table.Column<decimal>(type: "DECIMAL(14,6)", nullable: false),
                    GeoCoord_Latitude = table.Column<double>(type: "float", nullable: true),
                    GeoCoord_Longitude = table.Column<double>(type: "float", nullable: true),
                    GeoRegion = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    GeoSubRegion = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    GeoWorldRegion = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    TopLevelDomains = table.Column<string>(type: "nvarchar(31)", maxLength: 31, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
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
                name: "StoreOwners",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
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
                    table.PrimaryKey("PK_StoreOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryLocalName",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLocalName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLocalName_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    CountryAcceptsCurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyIsLegalTenderForCountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => new { x.CountryAcceptsCurrencyId, x.CurrencyIsLegalTenderForCountryId });
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Countries_CurrencyIsLegalTenderForCountryId",
                        column: x => x.CurrencyIsLegalTenderForCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Currencies_CountryAcceptsCurrencyId",
                        column: x => x.CountryAcceptsCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PhysicalMoney_Amount = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    PhysicalMoney_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    OwnerRelId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
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
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_StoreOwners_OwnerRelId",
                        column: x => x.OwnerRelId,
                        principalTable: "StoreOwners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CurrencyCashBalances",
                columns: table => new
                {
                    StoreId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Amount_Amount = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    Amount_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    OperationLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_CurrencyCashBalances", x => new { x.StoreId, x.CurrencyId });
                    table.ForeignKey(
                        name: "FK_CurrencyCashBalances_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyCashBalances_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreSecurityPasswords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    SecurityCamerasPassword = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    StoreRelId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
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
                    table.PrimaryKey("PK_StoreSecurityPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSecurityPasswords_Stores_StoreRelId",
                        column: x => x.StoreRelId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrencyIsLegalTenderForCountryId",
                table: "CountryCurrency",
                column: "CurrencyIsLegalTenderForCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLocalName_CountryId",
                table: "CountryLocalName",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyCashBalances_CurrencyId",
                table: "CurrencyCashBalances",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyCashBalances_StoreId",
                table: "CurrencyCashBalances",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_OwnerRelId",
                table: "Stores",
                column: "OwnerRelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSecurityPasswords_StoreRelId",
                table: "StoreSecurityPasswords",
                column: "StoreRelId",
                unique: true,
                filter: "[StoreRelId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllNoxTypes");

            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "CountryLocalName");

            migrationBuilder.DropTable(
                name: "CurrencyCashBalances");

            migrationBuilder.DropTable(
                name: "StoreSecurityPasswords");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "StoreOwners");
        }
    }
}
