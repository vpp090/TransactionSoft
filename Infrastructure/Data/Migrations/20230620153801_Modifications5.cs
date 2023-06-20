using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Modifications5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTransactionSum",
                table: "Merchants");

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Transactions");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTransactionSum",
                table: "Merchants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
