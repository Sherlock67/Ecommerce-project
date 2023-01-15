using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandacommercedal.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_ProductCategorycategoryid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductCategorycategoryid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductCategorycategoryid",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "products",
                newName: "productcategoriescategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_products_productcategoriescategoryid",
                table: "products",
                column: "productcategoriescategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_productcategoriescategoryid",
                table: "products",
                column: "productcategoriescategoryid",
                principalTable: "productCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_productcategoriescategoryid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_productcategoriescategoryid",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "productcategoriescategoryid",
                table: "products",
                newName: "categoryid");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategorycategoryid",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductCategorycategoryid",
                table: "products",
                column: "ProductCategorycategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_ProductCategorycategoryid",
                table: "products",
                column: "ProductCategorycategoryid",
                principalTable: "productCategories",
                principalColumn: "categoryid");
        }
    }
}
