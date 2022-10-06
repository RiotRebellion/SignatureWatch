using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignatureWatch.Infrastructure.Persistence.Migrations
{
    public partial class CompletedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractNumber = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Formulars",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SerialKey = table.Column<string>(type: "text", nullable: false),
                    OrgRegNumber = table.Column<string>(type: "text", nullable: false),
                    ProtectionKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulars", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareTypes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SoftwareLocation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareTypes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivationCode = table.Column<string>(type: "text", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "AccordanceSertificates",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RegNumber = table.Column<string>(type: "text", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProlongDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FormularGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccordanceSertificates", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_AccordanceSertificates_Formulars_FormularGuid",
                        column: x => x.FormularGuid,
                        principalTable: "Formulars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    OrgRegNumber = table.Column<string>(type: "text", nullable: false),
                    FormularGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Distributions_Formulars_FormularGuid",
                        column: x => x.FormularGuid,
                        principalTable: "Formulars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    SoftwareTypeGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DistributionGuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Softwares_Distributions_DistributionGuid",
                        column: x => x.DistributionGuid,
                        principalTable: "Distributions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Softwares_SoftwareTypes_SoftwareTypeGuid",
                        column: x => x.SoftwareTypeGuid,
                        principalTable: "SoftwareTypes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareLicenses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SupportGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareLicenses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_SoftwareLicenses_Contracts_ContractGuid",
                        column: x => x.ContractGuid,
                        principalTable: "Contracts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SoftwareLicenses_Softwares_SoftwareGuid",
                        column: x => x.SoftwareGuid,
                        principalTable: "Softwares",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SoftwareLicenses_Supports_SupportGuid",
                        column: x => x.SupportGuid,
                        principalTable: "Supports",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccordanceSertificates_FormularGuid",
                table: "AccordanceSertificates",
                column: "FormularGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_FormularGuid",
                table: "Distributions",
                column: "FormularGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicenses_ContractGuid",
                table: "SoftwareLicenses",
                column: "ContractGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicenses_SoftwareGuid",
                table: "SoftwareLicenses",
                column: "SoftwareGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicenses_SupportGuid",
                table: "SoftwareLicenses",
                column: "SupportGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_DistributionGuid",
                table: "Softwares",
                column: "DistributionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_SoftwareTypeGuid",
                table: "Softwares",
                column: "SoftwareTypeGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccordanceSertificates");

            migrationBuilder.DropTable(
                name: "SoftwareLicenses");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropTable(
                name: "SoftwareTypes");

            migrationBuilder.DropTable(
                name: "Formulars");
        }
    }
}
