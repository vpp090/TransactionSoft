using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Modifications3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Merchants_MerchantId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TType",
                table: "TransactionTypes");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "Transactions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Transactions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Merchants_MerchantId",
                table: "Transactions",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Merchants_MerchantId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TType",
                table: "TransactionTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Merchants_MerchantId",
                table: "Transactions",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
