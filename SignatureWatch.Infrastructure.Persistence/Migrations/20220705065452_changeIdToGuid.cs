using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class changeIdToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Signatures",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Signatures",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Employees",
                newName: "Id");
        }
    }
}
