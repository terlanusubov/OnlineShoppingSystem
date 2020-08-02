using Microsoft.EntityFrameworkCore.Migrations;

namespace GagiStoreSystem.Migrations
{
    public partial class DatabaseDiagramChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Specifications",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BakuKargo",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TurkeyKargo",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specifications",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BakuKargo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TurkeyKargo",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
