using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_Rocky_DataAccess.Migrations
{
    public partial class UpdateInquiryDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdCount",
                table: "InquiryDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdCount",
                table: "InquiryDetail");
        }
    }
}
