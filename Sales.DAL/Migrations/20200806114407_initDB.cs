using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.DAL.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Engincan Ozkan')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Halil Ibrahim Barlin')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Bilal Akcay')");

            migrationBuilder
                .Sql("INSERT INTO Sales (SoldProducts) Values ('Product1')");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
             .Sql("DELETE FROM Sales");

            migrationBuilder
             .Sql("DELETE FROM Customers");
        }
    }
}
