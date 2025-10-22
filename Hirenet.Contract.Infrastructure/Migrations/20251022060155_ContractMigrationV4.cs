using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hirenet.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContractMigrationV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MilestonesId",
                table: "Contracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MilestonesId",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
