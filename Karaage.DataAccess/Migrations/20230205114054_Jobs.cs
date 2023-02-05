using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Karaage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Jobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IngestionDate",
                table: "EntityElements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 2, 5, 11, 25, 57, 464, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IngestionDate",
                table: "EntityElements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 5, 11, 25, 57, 464, DateTimeKind.Utc).AddTicks(4457),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");
        }
    }
}
