using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.DAL.Migrations
{
    public partial class DbSaleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                            .Sql("INSERT INTO Sales (SoldProducts, ProductId, CustomerId) Values ('Product A',(SELECT Id FROM Products WHERE Name= 'Product A'), (SELECT Id FROM Customers WHERE Name = 'Sam'))");
            migrationBuilder
                            .Sql("INSERT INTO Sales (SoldProducts, ProductId, CustomerId) Values ('Product B',(SELECT Id FROM Products WHERE Name= 'Product B'), (SELECT Id FROM Customers WHERE Name = 'Jack'))");
            migrationBuilder
                            .Sql("INSERT INTO Sales (SoldProducts, ProductId, CustomerId) Values ('Product C',(SELECT Id FROM Products WHERE Name= 'Product C'), (SELECT Id FROM Customers WHERE Name = 'Hannah'))");
            migrationBuilder
                            .Sql("INSERT INTO Sales (SoldProducts, ProductId, CustomerId) Values ('Product D',(SELECT Id FROM Products WHERE Name= 'Product D'), (SELECT Id FROM Customers WHERE Name = 'Clay'))");
            migrationBuilder
                            .Sql("INSERT INTO Sales (SoldProducts, ProductId, CustomerId) Values ('Product E',(SELECT Id FROM Products WHERE Name= 'Product E'), (SELECT Id FROM Customers WHERE Name = 'Joe'))");
            migrationBuilder
                            .Sql("INSERT INTO Sales (SoldProducts, ProductId, CustomerId) Values ('Product F',(SELECT Id FROM Products WHERE Name= 'Product F'), (SELECT Id FROM Customers WHERE Name = 'William'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
