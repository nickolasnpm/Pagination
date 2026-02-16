using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pagination.Migrations
{
    /// <inheritdoc />
    public partial class Drop_Older_Table_With_Schema_Pagination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                DROP TABLE IF EXISTS [Pagination].[SupportTicketComment];
                DROP TABLE IF EXISTS [Pagination].[SupportTicket];
                DROP TABLE IF EXISTS [Pagination].[RoleUser];
                DROP TABLE IF EXISTS [Pagination].[Role];
                DROP TABLE IF EXISTS [Pagination].[LoanRepayment];
                DROP TABLE IF EXISTS [Pagination].[Loan];
                DROP TABLE IF EXISTS [Pagination].[CreditCardStatement];
                DROP TABLE IF EXISTS [Pagination].[CreditCard];
                DROP TABLE IF EXISTS [Pagination].[BankTransaction];
                DROP TABLE IF EXISTS [Pagination].[BankAccount];
                DROP TABLE IF EXISTS [Pagination].[Address];
                DROP TABLE IF EXISTS [Pagination].[Users];

                DROP SCHEMA IF EXISTS [Pagination];
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
