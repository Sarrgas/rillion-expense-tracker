using Application.Database;
using Application.Database.Entities;
using Application.Features;
using Application.Features.Expenses;
using FluentAssertions;
using Tests.Common;

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
    public async Task GivenNoExpensesExist_WhenAddingOneExpense_ThenContextContainsOneExpense()
    {
        await _sut.Handle(new AddExpense.Request(new AddedExpense(1220, ExpenseCategory.Food, "Storhandla")), CancellationToken.None);
        _context.Expenses.Should().HaveCount(1);
    }
    
}