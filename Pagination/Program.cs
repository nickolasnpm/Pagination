using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Pagination.Application.Configuration;
using Pagination.Application.Interface.Repository;
using Pagination.Domain.Entity;
using Pagination.Infrastructure;
using Pagination.Infrastructure.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region OData configuration
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<User>("UsersOData");
//modelBuilder.EntitySet<User>("Users");
//modelBuilder.EntitySet<Address>("Addresses");
//modelBuilder.EntitySet<BankAccount>("BankAccounts");
//modelBuilder.EntitySet<BankTransaction>("BankTransactions");
//modelBuilder.EntitySet<CreditCard>("CreditCards");
//modelBuilder.EntitySet<CreditCardStatement>("CreditCardStatements");
//modelBuilder.EntitySet<Loan>("Loans");
//modelBuilder.EntitySet<LoanRepayment>("LoanRepayments");
//modelBuilder.EntitySet<Role>("Roles");
//modelBuilder.EntitySet<SupportTicket>("SupportTickets");
//modelBuilder.EntitySet<SupportTicketComment>("SupportTicketComments");
var edmModel = modelBuilder.GetEdmModel();

builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .Count()
        .Expand()
        .SetMaxTop(1000)
        .AddRouteComponents("odata", edmModel));
#endregion

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

builder.Services.AddDbContextPool<UserDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions
            .EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null
            )
            .CommandTimeout(300);
        }
    )
    .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));

builder.Services.AddScoped<IOffsetRepository, OffsetRepository>();
builder.Services.AddScoped<ICursorRepository, CursorRepository>();
builder.Services.AddScoped<IUserODataRepository, UserODataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
