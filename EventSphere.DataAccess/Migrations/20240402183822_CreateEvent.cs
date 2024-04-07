using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventSphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGuest = table.Column<int>(type: "int", nullable: true),
                    MaxGuest = table.Column<int>(type: "int", nullable: true),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "eventCategories",
                columns: new[] { "Id", "Description", "MaxGuest", "MinGuest", "Offer", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Package for family get together.", 30, 10, "No available offer.", "Basic Birthday", "Birthday" },
                    { 2, "Package for official Conference.", 100, 20, "No available offer.", "Formal Conference", "Conference" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventCategories");
        }
    }
}
