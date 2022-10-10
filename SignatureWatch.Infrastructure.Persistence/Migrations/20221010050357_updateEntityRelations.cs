using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class updateEntityRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributions_Formulars_FormularGuid",
                table: "Distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Softwares_Distributions_DistributionGuid",
                table: "Softwares");

            migrationBuilder.DropIndex(
                name: "IX_Softwares_DistributionGuid",
                table: "Softwares");

            migrationBuilder.DropColumn(
                name: "DistributionGuid",
                table: "Softwares");

            migrationBuilder.RenameColumn(
                name: "FormularGuid",
                table: "Distributions",
                newName: "SoftwareGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Distributions_FormularGuid",
                table: "Distributions",
                newName: "IX_Distributions_SoftwareGuid");

            migrationBuilder.AddColumn<Guid>(
                name: "DistributionGuid",
                table: "Formulars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Formulars_DistributionGuid",
                table: "Formulars",
                column: "DistributionGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributions_Softwares_SoftwareGuid",
                table: "Distributions",
                column: "SoftwareGuid",
                principalTable: "Softwares",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Formulars_Distributions_DistributionGuid",
                table: "Formulars",
                column: "DistributionGuid",
                principalTable: "Distributions",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributions_Softwares_SoftwareGuid",
                table: "Distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Formulars_Distributions_DistributionGuid",
                table: "Formulars");

            migrationBuilder.DropIndex(
                name: "IX_Formulars_DistributionGuid",
                table: "Formulars");

            migrationBuilder.DropColumn(
                name: "DistributionGuid",
                table: "Formulars");

            migrationBuilder.RenameColumn(
                name: "SoftwareGuid",
                table: "Distributions",
                newName: "FormularGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Distributions_SoftwareGuid",
                table: "Distributions",
                newName: "IX_Distributions_FormularGuid");

            migrationBuilder.AddColumn<Guid>(
                name: "DistributionGuid",
                table: "Softwares",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_DistributionGuid",
                table: "Softwares",
                column: "DistributionGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributions_Formulars_FormularGuid",
                table: "Distributions",
                column: "FormularGuid",
                principalTable: "Formulars",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Softwares_Distributions_DistributionGuid",
                table: "Softwares",
                column: "DistributionGuid",
                principalTable: "Distributions",
                principalColumn: "Guid",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
