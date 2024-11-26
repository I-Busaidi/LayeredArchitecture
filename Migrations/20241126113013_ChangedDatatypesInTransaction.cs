using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayeredArchitecture.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDatatypesInTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_destinationAccNum",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_sourceAccNum",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "destinationAccNum",
                table: "Transactions",
                newName: "destinationAccId");

            migrationBuilder.RenameColumn(
                name: "sourceAccNum",
                table: "Transactions",
                newName: "sourceAccId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_sourceAccNum",
                table: "Transactions",
                newName: "IX_Transactions_sourceAccId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_destinationAccNum",
                table: "Transactions",
                newName: "IX_Transactions_destinationAccId");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_destinationAccId",
                table: "Transactions",
                column: "destinationAccId",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_sourceAccId",
                table: "Transactions",
                column: "sourceAccId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_destinationAccId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_sourceAccId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "destinationAccId",
                table: "Transactions",
                newName: "destinationAccNum");

            migrationBuilder.RenameColumn(
                name: "sourceAccId",
                table: "Transactions",
                newName: "sourceAccNum");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_sourceAccId",
                table: "Transactions",
                newName: "IX_Transactions_sourceAccNum");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_destinationAccId",
                table: "Transactions",
                newName: "IX_Transactions_destinationAccNum");

            migrationBuilder.AlterColumn<double>(
                name: "amount",
                table: "Transactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_destinationAccNum",
                table: "Transactions",
                column: "destinationAccNum",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_sourceAccNum",
                table: "Transactions",
                column: "sourceAccNum",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
