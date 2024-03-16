using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatoR_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroceryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                table: "Groceries");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingBagId",
                table: "Groceries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                table: "Groceries",
                column: "ShoppingBagId",
                principalTable: "ShoppingBags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                table: "Groceries");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingBagId",
                table: "Groceries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                table: "Groceries",
                column: "ShoppingBagId",
                principalTable: "ShoppingBags",
                principalColumn: "Id");
        }
    }
}
