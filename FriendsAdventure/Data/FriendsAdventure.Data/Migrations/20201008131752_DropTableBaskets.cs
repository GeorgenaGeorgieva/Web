using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAdventure.Data.Migrations
{
    public partial class DropTableBaskets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Baskets_BasketId",
                table: "ProductQuantities");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_BasketId",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "ProductQuantities");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductQuantities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_OrderId",
                table: "ProductQuantities",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Orders_OrderId",
                table: "ProductQuantities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Orders_OrderId",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_OrderId",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductQuantities");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "ProductQuantities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_BasketId",
                table: "ProductQuantities",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_OrderId",
                table: "Baskets",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Baskets_BasketId",
                table: "ProductQuantities",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
