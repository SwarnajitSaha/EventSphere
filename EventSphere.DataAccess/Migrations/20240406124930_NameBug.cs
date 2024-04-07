using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NameBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_eventCategories",
                table: "eventCategories");

            migrationBuilder.RenameTable(
                name: "eventCategories",
                newName: "EventCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                newName: "eventCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventCategories",
                table: "eventCategories",
                column: "Id");
        }
    }
}
