using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class addNullableOwnerToSignature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Signatures",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures",
                column: "OwnerId",
                principalTable: "Employees",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Signatures",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures",
                column: "OwnerId",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
