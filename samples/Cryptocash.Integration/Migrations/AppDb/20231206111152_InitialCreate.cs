using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cryptocash.Integration.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountriesQueryToCustomTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesQueryToCustomTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountriesQueryToTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Etag = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesQueryToTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountriesQueryToCustomTable");

            migrationBuilder.DropTable(
                name: "CountriesQueryToTable");
        }
    }
}
