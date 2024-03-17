using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatoR_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class IntiialReCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groceries_ShoppingBags_ShoppingBagId",
                        column: x => x.ShoppingBagId,
                        principalTable: "ShoppingBags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_ShoppingBagId",
                table: "Groceries",
                column: "ShoppingBagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "ShoppingBags");
        }
    }
}
