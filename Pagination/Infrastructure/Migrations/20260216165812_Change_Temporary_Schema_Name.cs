using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pagination.Migrations
{
    /// <inheritdoc />
    public partial class Change_Temporary_Schema_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pagination");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "PaginationTemp",
                newName: "Users",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "SupportTickets",
                schema: "PaginationTemp",
                newName: "SupportTickets",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "SupportTicketComments",
                schema: "PaginationTemp",
                newName: "SupportTicketComments",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                schema: "PaginationTemp",
                newName: "RoleUser",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "PaginationTemp",
                newName: "Roles",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "Loans",
                schema: "PaginationTemp",
                newName: "Loans",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "LoanRepayments",
                schema: "PaginationTemp",
                newName: "LoanRepayments",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "CreditCardStatements",
                schema: "PaginationTemp",
                newName: "CreditCardStatements",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                schema: "PaginationTemp",
                newName: "CreditCards",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "BankTransactions",
                schema: "PaginationTemp",
                newName: "BankTransactions",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                schema: "PaginationTemp",
                newName: "BankAccounts",
                newSchema: "Pagination");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "PaginationTemp",
                newName: "Addresses",
                newSchema: "Pagination");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Pagination",
                newName: "Users",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "SupportTickets",
                schema: "Pagination",
                newName: "SupportTickets",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "SupportTicketComments",
                schema: "Pagination",
                newName: "SupportTicketComments",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                schema: "Pagination",
                newName: "RoleUser",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Pagination",
                newName: "Roles",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "Loans",
                schema: "Pagination",
                newName: "Loans",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "LoanRepayments",
                schema: "Pagination",
                newName: "LoanRepayments",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "CreditCardStatements",
                schema: "Pagination",
                newName: "CreditCardStatements",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                schema: "Pagination",
                newName: "CreditCards",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "BankTransactions",
                schema: "Pagination",
                newName: "BankTransactions",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                schema: "Pagination",
                newName: "BankAccounts",
                newSchema: "PaginationTemp");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "Pagination",
                newName: "Addresses",
                newSchema: "PaginationTemp");
        }
    }
}
