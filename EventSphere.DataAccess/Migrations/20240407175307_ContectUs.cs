using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ContectUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContectUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContectUs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContectUs",
                columns: new[] { "Id", "Comment", "Email", "Name", "Phone" },
                values: new object[] { 1, "I Love your Program very much.", "Jon@gmail.com", "Jon Doe", "01789545215" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContectUs");
        }
    }
}
