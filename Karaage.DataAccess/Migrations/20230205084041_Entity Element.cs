using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karaage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EntityElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityElements",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IngestionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2023, 2, 5, 8, 40, 41, 316, DateTimeKind.Utc).AddTicks(9017)),
                    IngestionType = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityElements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityElements");
        }
    }
}
