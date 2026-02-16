using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pagination.Migrations
{
    /// <inheritdoc />
    public partial class Migrate_Data_From_Existing_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

            SET IDENTITY_INSERT PaginationTemp.Users ON;

            INSERT INTO PaginationTemp.Users 
            (Id, Username, Email, FirstName, LastName, DateOfBirth, PhoneNumber, ProfilePictureUrl, IsEmailVerified, IsActive, LastLoginAt, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, Username, Email, FirstName, LastName, DateOfBirth, PhoneNumber, ProfilePictureUrl, IsEmailVerified, IsActive, LastLoginAt, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.Users

            SET IDENTITY_INSERT PaginationTemp.Users OFF;


            SET IDENTITY_INSERT PaginationTemp.Addresses ON;

            INSERT INTO PaginationTemp.Addresses 
            (Id, AddressLine, City, State, PostalCode, Country, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, AddressLine, City, State, PostalCode, Country, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.Address

            SET IDENTITY_INSERT PaginationTemp.Addresses OFF;


            SET IDENTITY_INSERT PaginationTemp.BankAccounts ON;

            INSERT INTO PaginationTemp.BankAccounts 
            (Id, AccountNumber, CurrentBalance, AvailableBalance, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, AccountNumber, CurrentBalance, AvailableBalance, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.BankAccount

            SET IDENTITY_INSERT PaginationTemp.BankAccounts OFF;


            SET IDENTITY_INSERT PaginationTemp.BankTransactions ON;

            INSERT INTO PaginationTemp.BankTransactions 
            (Id, BaseAmount, FeeAmount, SettlementAmount, TransactionType, Status, MerchantName, ReferenceNumber, BankAccountId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, BaseAmount, FeeAmount, SettlementAmount, TransactionType, Status, MerchantName, ReferenceNumber, BankAccountId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.BankTransaction

            SET IDENTITY_INSERT PaginationTemp.BankTransactions OFF;

            
            SET IDENTITY_INSERT PaginationTemp.CreditCards ON;

            INSERT INTO PaginationTemp.CreditCards 
            (Id, CardNumber, CardHolderName, CardProvider, Bank, ExpiryMonth, ExpiryYear, IsDefault, CreditLimit, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, CardNumber, CardHolderName, CardProvider, Bank, ExpiryMonth, ExpiryYear, IsDefault, CreditLimit, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.CreditCard

            SET IDENTITY_INSERT PaginationTemp.CreditCards OFF;

            
            SET IDENTITY_INSERT PaginationTemp.CreditCardStatements ON;

            INSERT INTO PaginationTemp.CreditCardStatements 
            (Id, StatementDate, DueDate, StatementBalance, MinimumPayment, PaymentsReceived, InterestCharged, AvailableCredit, CreditCardId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, StatementDate, DueDate, StatementBalance, MinimumPayment, PaymentsReceived, InterestCharged, AvailableCredit, CreditCardId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.CreditCardStatement

            SET IDENTITY_INSERT PaginationTemp.CreditCardStatements OFF;


            SET IDENTITY_INSERT PaginationTemp.Loans ON;

            INSERT INTO PaginationTemp.Loans 
            (Id, LoanType, PrincipalAmount, InterestRate, InterestAmount, TotalAmountToRepay, RemainingBalance, TotalLoanTerms, RemainingLoanTerms, MonthlyPaymentAmount, IsFullyPaid, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, LoanType, PrincipalAmount, InterestRate, InterestAmount, TotalAmountToRepay, RemainingBalance, TotalLoanTerms, RemainingLoanTerms, MonthlyPaymentAmount, IsFullyPaid, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.Loan

            SET IDENTITY_INSERT PaginationTemp.Loans OFF;


            SET IDENTITY_INSERT PaginationTemp.LoanRepayments ON;

            INSERT INTO PaginationTemp.LoanRepayments 
            (Id, ScheduledDate, ActualPaymentDate, ScheduledAmount, PaidAmount, LoanId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, ScheduledDate, ActualPaymentDate, ScheduledAmount, PaidAmount, LoanId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.LoanRepayment

            SET IDENTITY_INSERT PaginationTemp.LoanRepayments OFF;

            
            SET IDENTITY_INSERT PaginationTemp.Roles ON;

            INSERT INTO PaginationTemp.Roles 
            (Id, Name, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, Name, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.Role

            SET IDENTITY_INSERT PaginationTemp.Roles OFF;


            INSERT INTO PaginationTemp.RoleUser 
            (RolesId, UsersId)
            SELECT 
            RolesId, UsersId
            FROM Pagination.RoleUser


            SET IDENTITY_INSERT PaginationTemp.SupportTickets ON;

            INSERT INTO PaginationTemp.SupportTickets
            (Id, Subject, Description, Priority, IsResolved, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, Subject, Description, Priority, IsResolved, UserId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.SupportTicket

            SET IDENTITY_INSERT PaginationTemp.SupportTickets OFF;


            SET IDENTITY_INSERT PaginationTemp.SupportTicketComments ON;

            INSERT INTO PaginationTemp.SupportTicketComments
            (Id, CommentText, RecommendedAction, TicketId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy)
            SELECT 
            Id, CommentText, RecommendedAction, TicketId, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy
            FROM Pagination.SupportTicketComment

            SET IDENTITY_INSERT PaginationTemp.SupportTicketComments OFF;

            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
