using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cryptocash.Integration.Migrations.NoxIntegrationDb
{
    /// <inheritdoc />
    public partial class IntegrationDbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "integration");

            migrationBuilder.CreateTable(
                name: "IntegrationMergeStates",
                schema: "integration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Integration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Property = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastDateLoadedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationMergeStates", x => x.Id);
                    table.UniqueConstraint("AK_IntegrationMergeStates_Integration_Property", x => new { x.Integration, x.Property });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationMergeStates",
                schema: "integration");
        }
    }
}
