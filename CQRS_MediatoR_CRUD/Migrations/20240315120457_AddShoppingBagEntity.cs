using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatoR_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingBagEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingBagId",
                table: "Groceries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingBags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_ShoppingBagId",
                table: "Groceries",
                column: "ShoppingBagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                table: "Groceries",
                column: "ShoppingBagId",
                principalTable: "ShoppingBags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                table: "Groceries");

            migrationBuilder.DropTable(
                name: "ShoppingBags");

            migrationBuilder.DropIndex(
                name: "IX_Groceries_ShoppingBagId",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "ShoppingBagId",
                table: "Groceries");
        }
    }
}
