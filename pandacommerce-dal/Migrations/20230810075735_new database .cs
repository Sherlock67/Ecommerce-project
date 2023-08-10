using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandacommercedal.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.RenameColumn(
                name: "categoryname",
                table: "productCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "productCategories",
                newName: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "productCategories",
                newName: "categoryname");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "productCategories",
                newName: "categoryid");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<int>(name: "product_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    fulldescription = table.Column<string>(name: "full_description", type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "nvarchar(max)", nullable: true),
                    shortdescription = table.Column<string>(name: "short_description", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });
        }
    }
}
