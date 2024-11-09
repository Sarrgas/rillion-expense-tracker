using Application.Database;
using Application.Database.Entities;
using Application.Features;
using FluentAssertions;
using Tests.Common;

//READ MORE HERE https://learn.microsoft.com/en-us/ef/core/testing/testing-without-the-database#sqlite-in-memory
namespace Tests;

public class AddExpenseTests
{
    private AddExpense.Handler _sut;
    private ExpensesDbContext _context;

    [SetUp]
    public void Setup()
    {
        _context = SqliteInMemoryDb.GetContext();
        _sut = new AddExpense.Handler(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public void GivenNoExpensesExist_WhenAddingOneExpense_ThenContextContainsOneExpense()
    {
        _sut.Handle(new AddExpense.Request(new Expense
        {
            Id = default,
            Amount = 1220,
            Category = ExpenseCategory.Food,
            Date = new DateTime(2020, 01, 01),
            Description = "Storhandla"
        }), CancellationToken.None);
        
        _context.Expenses.Should().HaveCount(1);
    }
    
}