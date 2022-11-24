using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_Rocky_DataAccess.Migrations
{
    public partial class AddOrders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_OrdersId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrdersId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Products",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrdersId",
                table: "Product",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_OrdersId",
                table: "Product",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
