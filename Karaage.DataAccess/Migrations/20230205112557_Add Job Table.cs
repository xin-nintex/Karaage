using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karaage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IngestionDate",
                table: "EntityElements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 5, 11, 25, 57, 464, DateTimeKind.Utc).AddTicks(4457),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 2, 5, 11, 12, 28, 302, DateTimeKind.Utc).AddTicks(3712));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IngestionDate",
                table: "EntityElements",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 5, 11, 12, 28, 302, DateTimeKind.Utc).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 2, 5, 11, 25, 57, 464, DateTimeKind.Utc).AddTicks(4457));
        }
    }
}
