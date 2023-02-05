using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karaage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.EnsureSchema(
                name: "Processing");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs",
                newSchema: "Processing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                schema: "Processing",
                table: "Jobs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                schema: "Processing",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                schema: "Processing",
                newName: "Job");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");
        }
    }
}
