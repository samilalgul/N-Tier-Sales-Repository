using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.DAL.Migrations
{
    public partial class DbSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Customer Seed
            migrationBuilder
               .Sql("INSERT INTO Customers (Name) Values ('John')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Joe')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Hannah')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('William')");
            migrationBuilder
               .Sql("INSERT INTO Customers (Name) Values ('Tara')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Sam')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Clay')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Jackie')");
            migrationBuilder
               .Sql("INSERT INTO Customers (Name) Values ('Mo')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Alvarez')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Robert')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Dan')");
            migrationBuilder
               .Sql("INSERT INTO Customers (Name) Values ('Lenny')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Gemma')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Charlie')");
            migrationBuilder
                .Sql("INSERT INTO Customers (Name) Values ('Ron')");
            // Product Seed
            migrationBuilder
                .Sql("INSERT INTO Products (Name,Type,Stock) Values ('Product A','System Hardware', 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
