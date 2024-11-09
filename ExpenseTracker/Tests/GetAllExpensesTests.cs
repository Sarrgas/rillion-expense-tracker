using Application.Database;
using Application.Database.Entities;
using Application.Features;
using Application.Features.Expenses;
using FluentAssertions;
using Tests.Common;


namespace Tests;

public class GetAllExpensesTests
{
    private GetAllExpenses.Handler _sut;
    private ExpensesDbContext _context;

    [SetUp]
    public void Setup()
    {
        _context = SqliteInMemoryDb.GetContext();
        _sut = new GetAllExpenses.Handler(_context);
    }
    
    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
    
    [Test]
    public async Task GivenFiveExpensesExist_WhenRetrievingExpensesList_ThenReturnListOfFiveExpenses()
    {
        await PrepareDatabaseWithFiveExpenses();
        
        var response = await _sut.Handle(new GetAllExpenses.ForUser(), CancellationToken.None);
        
        response.AllExpensesForUser.Should().HaveCount(5);
    }

    private async Task PrepareDatabaseWithFiveExpenses()
    {
        var existingExpenses = new List<Expense>
        {
            new()
            {
                Id = default,
                Amount = 149,
                Category = ExpenseCategory.Entertainment,
                Date = new DateTime(2020, 01, 01),
                Description = "Netflix"
            },
            new()
            {
                Id = default,
                Amount = 700,
                Category = ExpenseCategory.Food,
                Date = new DateTime(2020, 01, 04),
                Description = "Groceries"
            },
            new()
            {
                Id = default,
                Amount = 120,
                Category = ExpenseCategory.Food,
                Date = new DateTime(2020, 01, 07),
                Description = "Pizza"
            },
            new()
            {
                Id = default,
                Amount = 650,
                Category = ExpenseCategory.Utilities,
                Date = new DateTime(2020, 02, 01),
                Description = "Gasoline"
            },
            new()
            {
                Id = default,
                Amount = 650,
                Category = ExpenseCategory.Utilities,
                Date = new DateTime(2020, 02, 05),
                Description = "Internet"
            },
        };
        
        _context.Expenses.AddRange(existingExpenses);
        await _context.SaveChangesAsync();
    }
}