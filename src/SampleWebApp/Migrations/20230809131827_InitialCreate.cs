using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebApp.Migrations
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
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NuidField = table.Column<long>(type: "bigint", nullable: true),
                    BooleanField = table.Column<bool>(type: "bit", nullable: true),
                    CountryCode2Field = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    CountryCode3Field = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    NumberField = table.Column<int>(type: "int", nullable: true),
                    TextField = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    StreetAddressField_StreetNumber = table.Column<int>(type: "int", nullable: true),
                    StreetAddressField_AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_Locality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_AdministrativeArea1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_AdministrativeArea2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressField_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileField_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileField_PrettyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileField_SizeInBytes = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    TranslatedTextField_Phrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedTextField_CultureCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumberField_Number = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    VatNumberField_CountryCode2 = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    PasswordField_HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordField_Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyField_Amount = table.Column<decimal>(type: "decimal(13,4)", nullable: true),
                    MoneyField_CurrencyCode = table.Column<int>(type: "int", nullable: true),
                    HashedTexField_HashText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashedTexField_Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatLongField_Latitude = table.Column<decimal>(type: "decimal(8,6)", precision: 8, scale: 6, nullable: true),
                    LatLongField_Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllNoxTypes", x => new { x.Id, x.TextId });
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    FormalName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    AlphaCode3 = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    AlphaCode2 = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    NumericCode = table.Column<short>(type: "smallint", nullable: false),
                    DialingCodes = table.Column<string>(type: "varchar(31)", unicode: false, maxLength: 31, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    Demonym = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: true),
                    AreaInSquareKilometres = table.Column<decimal>(type: "DECIMAL(14,6)", nullable: false),
                    GeoCoord_Latitude = table.Column<decimal>(type: "decimal(8,6)", precision: 8, scale: 6, nullable: true),
                    GeoCoord_Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    GeoRegion = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    GeoSubRegion = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    GeoWorldRegion = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    TopLevelDomains = table.Column<string>(type: "nvarchar(31)", maxLength: 31, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryLocalNames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLocalNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    PhysicalMoney_Amount = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    PhysicalMoney_CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    CountriesId = table.Column<string>(type: "char(2)", nullable: false),
                    CurrenciesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => new { x.CountriesId, x.CurrenciesId });
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Currencies",
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
                    StoreId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSecurityPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSecurityPasswords_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrenciesId",
                table: "CountryCurrency",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSecurityPasswords_StoreId",
                table: "StoreSecurityPasswords",
                column: "StoreId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllNoxTypes");

            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "CountryLocalNames");

            migrationBuilder.DropTable(
                name: "StoreSecurityPasswords");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
