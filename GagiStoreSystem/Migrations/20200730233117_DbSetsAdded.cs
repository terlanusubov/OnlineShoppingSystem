using Microsoft.EntityFrameworkCore.Migrations;

namespace GagiStoreSystem.Migrations
{
    public partial class DbSetsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cost_Orders_OrderId",
                table: "Cost");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Packet_PacketId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packet",
                table: "Packet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cost",
                table: "Cost");

            migrationBuilder.RenameTable(
                name: "Packet",
                newName: "Packets");

            migrationBuilder.RenameTable(
                name: "Cost",
                newName: "Costs");

            migrationBuilder.RenameIndex(
                name: "IX_Cost_OrderId",
                table: "Costs",
                newName: "IX_Costs_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packets",
                table: "Packets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costs",
                table: "Costs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PacketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacketStatuses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Orders_OrderId",
                table: "Costs",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Packets_PacketId",
                table: "Orders",
                column: "PacketId",
                principalTable: "Packets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Orders_OrderId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Packets_PacketId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "PacketStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packets",
                table: "Packets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costs",
                table: "Costs");

            migrationBuilder.RenameTable(
                name: "Packets",
                newName: "Packet");

            migrationBuilder.RenameTable(
                name: "Costs",
                newName: "Cost");

            migrationBuilder.RenameIndex(
                name: "IX_Costs_OrderId",
                table: "Cost",
                newName: "IX_Cost_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packet",
                table: "Packet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cost",
                table: "Cost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cost_Orders_OrderId",
                table: "Cost",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Packet_PacketId",
                table: "Orders",
                column: "PacketId",
                principalTable: "Packet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
