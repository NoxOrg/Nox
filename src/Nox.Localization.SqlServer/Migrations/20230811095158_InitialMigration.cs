using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nox.Localization.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "l10n");

            migrationBuilder.CreateTable(
                name: "Translations",
                schema: "l10n",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourceKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Validated = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.UniqueConstraint("AK_Translations_Key_CultureCode_ResourceKey", x => new { x.Key, x.CultureCode, x.ResourceKey });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations",
                schema: "l10n");
        }
    }
}
