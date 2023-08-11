using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nox.Localization.Sqlite.Migrations
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CultureCode = table.Column<string>(type: "TEXT", nullable: false),
                    ResourceKey = table.Column<string>(type: "TEXT", nullable: false),
                    Validated = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastUpdatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
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
