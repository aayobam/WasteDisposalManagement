using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteDisposalManagement.Migrations
{
    public partial class renamestatestostate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "States",
                table: "AspNetUsers",
                newName: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "States");
        }
    }
}
