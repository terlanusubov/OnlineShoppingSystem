using Microsoft.EntityFrameworkCore.Migrations;

namespace GagiStoreSystem.Migrations
{
    public partial class PacketAndCostAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacketId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostAmount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cost_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packet", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PacketId",
                table: "Orders",
                column: "PacketId");

            migrationBuilder.CreateIndex(
                name: "IX_Cost_OrderId",
                table: "Cost",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Packet_PacketId",
                table: "Orders",
                column: "PacketId",
                principalTable: "Packet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Packet_PacketId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Cost");

            migrationBuilder.DropTable(
                name: "Packet");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PacketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PacketId",
                table: "Orders");
        }
    }
}
