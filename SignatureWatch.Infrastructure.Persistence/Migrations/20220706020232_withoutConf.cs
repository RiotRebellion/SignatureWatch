using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class withoutConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Employees_OwnerId",
                table: "Signatures");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Signatures",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Employees",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "NEWID()");

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
                name: "Guid",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Signatures",
                type: "uuid",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
