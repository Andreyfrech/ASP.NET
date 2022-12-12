using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_Rocky_DataAccess.Migrations
{
    public partial class DeleteOrder1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Orders");

            migrationBuilder.DropTable(
                name: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Orders");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
