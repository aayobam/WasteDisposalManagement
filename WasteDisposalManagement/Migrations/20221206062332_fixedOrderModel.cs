using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteDisposalManagement.Migrations
{
    public partial class fixedOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstTimeOrders_Services_ServicesNameNavigationServiceId",
                table: "FirstTimeOrders");

            migrationBuilder.DropColumn(
                name: "ServicesName",
                table: "FirstTimeOrders");

            migrationBuilder.RenameColumn(
                name: "ServicesNameNavigationServiceId",
                table: "FirstTimeOrders",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_FirstTimeOrders_ServicesNameNavigationServiceId",
                table: "FirstTimeOrders",
                newName: "IX_FirstTimeOrders_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstTimeOrders_Services_ServiceId",
                table: "FirstTimeOrders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstTimeOrders_Services_ServiceId",
                table: "FirstTimeOrders");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "FirstTimeOrders",
                newName: "ServicesNameNavigationServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_FirstTimeOrders_ServiceId",
                table: "FirstTimeOrders",
                newName: "IX_FirstTimeOrders_ServicesNameNavigationServiceId");

            migrationBuilder.AddColumn<string>(
                name: "ServicesName",
                table: "FirstTimeOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstTimeOrders_Services_ServicesNameNavigationServiceId",
                table: "FirstTimeOrders",
                column: "ServicesNameNavigationServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
