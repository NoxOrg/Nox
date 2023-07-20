using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nox.Integration.Store.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Integrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MergeAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inserts = table.Column<int>(type: "int", nullable: false),
                    Updates = table.Column<int>(type: "int", nullable: false),
                    Unchanged = table.Column<int>(type: "int", nullable: false),
                    IntegrationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeAnalytics_Integrations_IntegrationId",
                        column: x => x.IntegrationId,
                        principalTable: "Integrations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MergeStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDateLoadedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeStates_Integrations_IntegrationId",
                        column: x => x.IntegrationId,
                        principalTable: "Integrations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MergeAnalytics_IntegrationId",
                table: "MergeAnalytics",
                column: "IntegrationId");

            migrationBuilder.CreateIndex(
                name: "IX_MergeStates_IntegrationId",
                table: "MergeStates",
                column: "IntegrationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MergeAnalytics");

            migrationBuilder.DropTable(
                name: "MergeStates");

            migrationBuilder.DropTable(
                name: "Integrations");
        }
    }
}
