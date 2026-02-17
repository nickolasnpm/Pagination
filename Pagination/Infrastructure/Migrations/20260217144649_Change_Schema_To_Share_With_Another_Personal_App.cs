using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pagination.Migrations
{
    /// <inheritdoc />
    public partial class Change_Schema_To_Share_With_Another_Personal_App : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Performance");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Pagination",
                newName: "Users",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "SupportTickets",
                schema: "Pagination",
                newName: "SupportTickets",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "SupportTicketComments",
                schema: "Pagination",
                newName: "SupportTicketComments",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                schema: "Pagination",
                newName: "RoleUser",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Pagination",
                newName: "Roles",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "Loans",
                schema: "Pagination",
                newName: "Loans",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "LoanRepayments",
                schema: "Pagination",
                newName: "LoanRepayments",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "CreditCardStatements",
                schema: "Pagination",
                newName: "CreditCardStatements",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                schema: "Pagination",
                newName: "CreditCards",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "BankTransactions",
                schema: "Pagination",
                newName: "BankTransactions",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                schema: "Pagination",
                newName: "BankAccounts",
                newSchema: "Performance");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "Pagination",
                newName: "Addresses",
                newSchema: "Performance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pagination");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Performance",
                newName: "Users",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "SupportTickets",
                schema: "Performance",
                newName: "SupportTickets",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "SupportTicketComments",
                schema: "Performance",
                newName: "SupportTicketComments",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                schema: "Performance",
                newName: "RoleUser",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Performance",
                newName: "Roles",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "Loans",
                schema: "Performance",
                newName: "Loans",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "LoanRepayments",
                schema: "Performance",
                newName: "LoanRepayments",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "CreditCardStatements",
                schema: "Performance",
                newName: "CreditCardStatements",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                schema: "Performance",
                newName: "CreditCards",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "BankTransactions",
                schema: "Performance",
                newName: "BankTransactions",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                schema: "Performance",
                newName: "BankAccounts",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "Performance",
                newName: "Addresses",
                newSchema: "Pagination");
        }
    }
}
