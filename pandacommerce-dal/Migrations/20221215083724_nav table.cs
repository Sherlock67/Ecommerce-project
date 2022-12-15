using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandacommercedal.Migrations
{
    /// <inheritdoc />
    public partial class navtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "navCategories",
                columns: table => new
                {
                    NavCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NavCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navCategories", x => x.NavCategoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "navCategories");
        }
    }
}
