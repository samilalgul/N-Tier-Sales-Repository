using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.DAL.Migrations
{
    public partial class DbSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Product Seed
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product A','System Hardware', 20)");
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product B','Network Hardware', 20)");
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product C','Wireless Hardware', 20)");
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product D','Tools', 20)");
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product E','OS', 20)");
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product F','WMSoftware', 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
