using Microsoft.EntityFrameworkCore.Migrations;

namespace GagiStoreSystem.Migrations
{
    public partial class PacketStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacketStatusId",
                table: "Packet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "Packet",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PacketStatusId",
                table: "Packet");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Packet");
        }
    }
}
