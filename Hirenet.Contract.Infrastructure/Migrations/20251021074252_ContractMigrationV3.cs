using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hirenet.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContractMigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Milestones_Contracts_JobContractContractId",
                table: "Milestones");

            migrationBuilder.DropIndex(
                name: "IX_Milestones_JobContractContractId",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "JobContractContractId",
                table: "Milestones");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Milestones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MilestonesId",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_ContractId",
                table: "Milestones",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestones_Contracts_ContractId",
                table: "Milestones",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Milestones_Contracts_ContractId",
                table: "Milestones");

            migrationBuilder.DropIndex(
                name: "IX_Milestones_ContractId",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Milestones");

            migrationBuilder.DropColumn(
                name: "MilestonesId",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "JobContractContractId",
                table: "Milestones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_JobContractContractId",
                table: "Milestones",
                column: "JobContractContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestones_Contracts_JobContractContractId",
                table: "Milestones",
                column: "JobContractContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId");
        }
    }
}
