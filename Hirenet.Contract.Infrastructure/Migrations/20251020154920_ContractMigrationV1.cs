using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hirenet.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContractMigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilestoneTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilestoneDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilestoneEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobContractContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.MilestoneId);
                    table.ForeignKey(
                        name: "FK_Milestones_Contracts_JobContractContractId",
                        column: x => x.JobContractContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "MilestoneFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MilestoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestoneFiles", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_MilestoneFiles_Milestones_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestones",
                        principalColumn: "MilestoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilestoneFiles_MilestoneId",
                table: "MilestoneFiles",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_JobContractContractId",
                table: "Milestones",
                column: "JobContractContractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilestoneFiles");

            migrationBuilder.DropTable(
                name: "Milestones");

            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
