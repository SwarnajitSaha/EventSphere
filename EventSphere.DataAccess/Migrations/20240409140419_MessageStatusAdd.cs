using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MessageStatusAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ContectUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ContectUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "unread");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContectUs");
        }
    }
}
