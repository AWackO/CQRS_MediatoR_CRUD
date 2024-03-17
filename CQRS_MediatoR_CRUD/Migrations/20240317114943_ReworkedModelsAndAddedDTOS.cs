using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatoR_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedModelsAndAddedDTOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "ShoppingBags",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "ShoppingBags");
        }
    }
}
