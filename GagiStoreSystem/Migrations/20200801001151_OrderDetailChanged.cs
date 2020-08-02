using Microsoft.EntityFrameworkCore.Migrations;

namespace GagiStoreSystem.Migrations
{
    public partial class OrderDetailChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BakuKargo",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TurkeyKargo",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailStatusId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDetailStatusId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "BakuKargo",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TurkeyKargo",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
