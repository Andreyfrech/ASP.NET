using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_Rocky_DataAccess.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_InquiryDetails_InquiryHeader_InquiryHeaderId",
            //    table: "InquiryDetail");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_InquiryDetail_Product_ProductId",
            //    table: "InquiryDetail");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_InquiryDetail",
            //    table: "InquiryDetail");

            //migrationBuilder.DropColumn(
            //    name: "CountInCart",
            //    table: "Product");

            //migrationBuilder.RenameTable(
            //    name: "InquiryDetails",
            //    newName: "InquiryDetail");

            //migrationBuilder.RenameIndex(
            //    name: "IX_InquiryDetail_ProductId",
            //    table: "InquiryDetail",
            //    newName: "IX_InquiryDetail_ProductId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_InquiryDetail_InquiryHeaderId",
            //    table: "InquiryDetail",
            //    newName: "IX_InquiryDetail_InquiryHeaderId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_InquiryDetail",
            //    table: "InquiryDetail",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_InquiryDetail_InquiryHeader_InquiryHeaderId",
            //    table: "InquiryDetail",
            //    column: "InquiryHeaderId",
            //    principalTable: "InquiryHeader",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_InquiryDetail_Product_ProductId",
            //    table: "InquiryDetail",
            //    column: "ProductId",
            //    principalTable: "Product",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_InquiryDetails_InquiryHeader_InquiryHeaderId",
            //    table: "InquiryDetail");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_InquiryDetail_Product_ProductId",
            //    table: "InquiryDetail");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_InquiryDetail",
            //    table: "InquiryDetail");

            //migrationBuilder.RenameTable(
            //    name: "InquiryDetail",
            //    newName: "InquiryDetail ");

            //migrationBuilder.RenameIndex(
            //    name: "IX_InquiryDetail_ProductId",
            //    table: "InquiryDetail",
            //    newName: "IX_InquiryDetail_ProductId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_InquiryDetail_InquiryHeaderId",
            //    table: "InquiryDetail",
            //    newName: "IX_InquiryDetails_InquiryHeaderId");

            migrationBuilder.AddColumn<int>(
                name: "CountInCart",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_InquiryDetail",
            //    table: "InquiryDetail",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_InquiryDetail_InquiryHeader_InquiryHeaderId",
            //    table: "InquiryDetail",
            //    column: "InquiryHeaderId",
            //    principalTable: "InquiryHeader",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_InquiryDetail_Product_ProductId",
            //    table: "InquiryDetail",
            //    column: "ProductId",
            //    principalTable: "Product",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
