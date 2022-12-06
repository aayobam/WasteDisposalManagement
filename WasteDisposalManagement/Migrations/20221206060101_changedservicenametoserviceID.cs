using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteDisposalManagement.Migrations
{
    public partial class changedservicenametoserviceID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServicesNameNavigationServiceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ServicesName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ServicesNameNavigationServiceId",
                table: "Orders",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ServicesNameNavigationServiceId",
                table: "Orders",
                newName: "IX_Orders_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Orders",
                newName: "ServicesNameNavigationServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                newName: "IX_Orders_ServicesNameNavigationServiceId");

            migrationBuilder.AddColumn<string>(
                name: "ServicesName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServicesNameNavigationServiceId",
                table: "Orders",
                column: "ServicesNameNavigationServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
