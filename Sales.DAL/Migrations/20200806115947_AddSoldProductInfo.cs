using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.DAL.Migrations
{
    public partial class AddSoldProductInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoldProducts",
                table: "Sales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoldProducts",
                table: "Sales");
        }
    }
}
