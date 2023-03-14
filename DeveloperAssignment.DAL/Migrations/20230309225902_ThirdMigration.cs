using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperAssignment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
                
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Electronics" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Kitchen" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Clothing" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 4, "Automobiles" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Cameras" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Jewellery" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 7, "Musical Instruments" });
            migrationBuilder.InsertData(table: "Category", columns: new[] { "CategoryId", "Name" },
                values: new object[] { 8, "Sporting Equipment" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryId",
                table: "Item");
        }
    }
}
