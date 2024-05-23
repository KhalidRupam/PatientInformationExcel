using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NCDs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientInformations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActve = table.Column<bool>(type: "bit", nullable: false),
                    DiseaseId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Epliepsy = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientInformations_DiseaseInformations",
                        column: x => x.DiseaseId,
                        principalTable: "DiseaseInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Allergies_Details",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AllergieId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_Details_Allergies",
                        column: x => x.AllergieId,
                        principalTable: "Allergies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Allergies_Details_PatientInformations",
                        column: x => x.PatientId,
                        principalTable: "PatientInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NCDId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCD_Details_NCDs",
                        column: x => x.NCDId,
                        principalTable: "NCDs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NCD_Details_PatientInformations",
                        column: x => x.PatientId,
                        principalTable: "PatientInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_AllergieId",
                table: "Allergies_Details",
                column: "AllergieId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_PatientId",
                table: "Allergies_Details",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_NCDId",
                table: "NCD_Details",
                column: "NCDId");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientId",
                table: "NCD_Details",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInformations_DiseaseId",
                table: "PatientInformations",
                column: "DiseaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies_Details");

            migrationBuilder.DropTable(
                name: "NCD_Details");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCDs");

            migrationBuilder.DropTable(
                name: "PatientInformations");

            migrationBuilder.DropTable(
                name: "DiseaseInformations");
        }
    }
}
