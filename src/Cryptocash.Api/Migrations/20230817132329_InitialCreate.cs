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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_StreetNumber = table.Column<int>(type: "int", nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_StreetNumber = table.Column<int>(type: "int", nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AdministrativeArea1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AdministrativeArea2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_CountryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstWorkingDay = table.Column<DateTime>(type: "date", nullable: false),
                    LastWorkingDay = table.Column<DateTime>(type: "date", nullable: true),
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
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
