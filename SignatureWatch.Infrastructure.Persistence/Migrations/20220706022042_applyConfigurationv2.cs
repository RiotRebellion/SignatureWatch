using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class applyConfigurationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures");

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures",
                column: "OwnerId",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures");

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures",
                column: "OwnerId",
                principalTable: "Employees",
                principalColumn: "Guid");
        }
    }
}
