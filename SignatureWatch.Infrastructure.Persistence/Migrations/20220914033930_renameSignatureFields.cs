using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class renameSignatureFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Signatures",
                newName: "OwnerGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Signatures_OwnerId",
                table: "Signatures",
                newName: "IX_Signatures_OwnerGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Employees_OwnerGuid",
                table: "Signatures",
                column: "OwnerGuid",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerGuid",
                table: "Signatures");

            migrationBuilder.RenameColumn(
                name: "OwnerGuid",
                table: "Signatures",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Signatures_OwnerGuid",
                table: "Signatures",
                newName: "IX_Signatures_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures",
                column: "OwnerId",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
