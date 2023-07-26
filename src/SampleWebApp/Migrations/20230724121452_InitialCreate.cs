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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(2)", unicode: false, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(63)", nullable: false),
                    FormalName = table.Column<string>(type: "NVARCHAR(63)", nullable: false),
                    AlphaCode3 = table.Column<string>(type: "CHAR(3)", unicode: false, nullable: false),
                    AlphaCode2 = table.Column<string>(type: "CHAR(2)", unicode: false, nullable: false),
                    NumericCode = table.Column<short>(type: "smallint", nullable: false),
                    DialingCodes = table.Column<string>(type: "VARCHAR(31)", unicode: false, nullable: true),
                    Capital = table.Column<string>(type: "NVARCHAR(63)", nullable: true),
                    Demonym = table.Column<string>(type: "NVARCHAR(63)", nullable: true),
                    AreaInSquareKilometres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeoRegion = table.Column<string>(type: "VARCHAR(8)", unicode: false, nullable: false),
                    GeoSubRegion = table.Column<string>(type: "VARCHAR(32)", unicode: false, nullable: false),
                    GeoWorldRegion = table.Column<string>(type: "VARCHAR(4)", unicode: false, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    TopLevelDomains = table.Column<string>(type: "NVARCHAR(31)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(3)", unicode: false, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(63)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(3)", unicode: false, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(63)", nullable: false),
                    PhysicalMoney_Amount = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    PhysicalMoney_CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryLocalNames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(2)", unicode: false, nullable: false),
                    CountryId = table.Column<string>(type: "CHAR(2)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLocalNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLocalNames_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    CountriesId = table.Column<string>(type: "CHAR(2)", nullable: false),
                    CurrenciesId = table.Column<string>(type: "CHAR(3)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrenciesId",
                table: "CountryCurrency",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLocalNames_CountryId",
                table: "CountryLocalNames",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "CountryLocalNames");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
